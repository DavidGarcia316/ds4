using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LibreriaWeb.Models;

namespace LibreriaWeb.BaseDatos
{
    public class AccesoDatos
    {
        private string cadena = ConfigurationManager.ConnectionStrings["LibreriaConn"].ConnectionString;

        // --- MÉTODOS EXISTENTES ---

        public List<Libro> ObtenerLibros()
        {
            List<Libro> lista = new List<Libro>();
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string query = "SELECT L.IdLibro, L.Titulo, L.Categoria, L.Precio, L.Stock, E.Nombre as Estado FROM Libros L JOIN Estados E ON L.IdEstado = E.IdEstado";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Libro
                        {
                            IdLibro = Convert.ToInt32(dr["IdLibro"]),
                            Titulo = dr["Titulo"].ToString(),
                            Categoria = dr["Categoria"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            Stock = Convert.ToInt32(dr["Stock"]),
                            NombreEstado = dr["Estado"].ToString()
                        });
                    }
                }
            }
            catch { }
            return lista;
        }

        public string RegistrarVenta(string cliente, int idLibro, int cantidad)
        {
            string mensaje = "";
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cliente", cliente);
                    cmd.Parameters.AddWithValue("@IdLibro", idLibro);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    con.Open();
                    object res = cmd.ExecuteScalar();
                    if (res != null) mensaje = res.ToString();
                }
            }
            catch (Exception ex) { mensaje = ex.Message; }
            return mensaje;
        }

        public Usuario ValidarLogin(string email, string password)
        {
            Usuario usuario = null;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new Usuario
                    {
                        Email = email,
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Rol = dr["Rol"].ToString()
                    };
                }
            }
            return usuario;
        }

        // --- MÉTODOS NUEVOS AGREGADOS ---

        // 1. CLIENTE: Solicitar un libro (Agregar al "Carrito")
        public bool SolicitarLibro(int idUsuario, string nombreCliente, int idLibro, string tituloLibro)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string query = "INSERT INTO Pedidos (IdUsuario, NombreCliente, IdLibro, TituloLibro) VALUES (@IdU, @Nom, @IdL, @Tit)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdU", idUsuario);
                    cmd.Parameters.AddWithValue("@Nom", nombreCliente);
                    cmd.Parameters.AddWithValue("@IdL", idLibro);
                    cmd.Parameters.AddWithValue("@Tit", tituloLibro);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch { return false; }
        }

        // 2. VENDEDOR: Ver qué han pedido los clientes
        public List<Pedido> ObtenerPedidosPendientes()
        {
            List<Pedido> lista = new List<Pedido>();
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string query = "SELECT * FROM Pedidos WHERE Estado = 'Pendiente' ORDER BY Fecha DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Pedido
                        {
                            IdPedido = Convert.ToInt32(dr["IdPedido"]),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            TituloLibro = dr["TituloLibro"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            IdLibro = Convert.ToInt32(dr["IdLibro"])
                        });
                    }
                }
            }
            catch { }
            return lista;
        }

        // 3. VENDEDOR: Aprobar pedido (Resta Stock y cierra el pedido)
        public void AprobarPedido(int idPedido, string cliente, int idLibro, int cantidad)
        {
            // Primero registramos la venta real (resta stock)
            RegistrarVenta(cliente, idLibro, cantidad);

            // Luego marcamos el pedido como Aprobado para que desaparezca de la lista
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string query = "UPDATE Pedidos SET Estado = 'Aprobado' WHERE IdPedido = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", idPedido);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 4. VENDEDOR: Registrar nuevo usuario
        public bool RegistrarNuevoCliente(string nombre, string email, string pass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Parameters.AddWithValue("@Rol", "Cliente"); // Forzamos el rol Cliente
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch { return false; }
        }
        // Método para Agregar Libro Nuevo o Sumar Stock
        public bool AgregarLibro(string titulo, string categoria, decimal precio, int stock)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarLibro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Stock", stock);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}