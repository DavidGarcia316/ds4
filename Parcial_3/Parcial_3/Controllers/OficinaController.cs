using Parcial_3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Parcial_3.Controllers
{
    public class OficinaController : Controller
    {
        private string _cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionSistema"].ConnectionString;

        public ActionResult Inicio() 
        {
            List<Expediente> listado = new List<Expediente>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    string sql = "SELECT t.IdTramite, c.Nombres, c.Apellidos, c.CedulaIdentidad, t.EstadoActual, t.FechaRegistro " +
                                 "FROM TramitesPasaporte t JOIN Ciudadanos c ON t.IdCiudadano = c.IdCiudadano";

                    SqlCommand comando = new SqlCommand(sql, conexion);
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        listado.Add(new Expediente
                        {
                            IdTramite = Convert.ToInt32(lector["IdTramite"]),
                            Nombres = lector["Nombres"].ToString(),
                            Apellidos = lector["Apellidos"].ToString(),
                            CedulaIdentidad = lector["CedulaIdentidad"].ToString(),
                            EstadoActual = lector["EstadoActual"].ToString(),
                            FechaRegistro = Convert.ToDateTime(lector["FechaRegistro"])
                        });
                    }
                }
            }
            catch (Exception ex) { ViewBag.Mensaje = ex.Message; }
            return View(listado);
        }

        public ActionResult NuevoTramite() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoTramite(Expediente datos)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(_cadenaConexion))
                {
                    conn.Open();
                    int idPersona = 0;

                    SqlCommand cmdBuscar = new SqlCommand("SELECT IdCiudadano FROM Ciudadanos WHERE CedulaIdentidad = @ced", conn);
                    cmdBuscar.Parameters.AddWithValue("@ced", datos.CedulaIdentidad);

                    object existe = cmdBuscar.ExecuteScalar();

                    if (existe != null)
                    {
                        idPersona = Convert.ToInt32(existe);
                    }
                    else
                    {
                        string sqlInsert = "INSERT INTO Ciudadanos (CedulaIdentidad, Nombres, Apellidos, Nacimiento, CorreoElectronico) " +
                                           "VALUES (@ced, @nom, @ape, @nac, @mail); SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        cmdInsert.Parameters.AddWithValue("@ced", datos.CedulaIdentidad);
                        cmdInsert.Parameters.AddWithValue("@nom", datos.Nombres);
                        cmdInsert.Parameters.AddWithValue("@ape", datos.Apellidos);
                        cmdInsert.Parameters.AddWithValue("@nac", datos.Nacimiento);
                        cmdInsert.Parameters.AddWithValue("@mail", datos.CorreoElectronico ?? "");

                        idPersona = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }

                    SqlCommand cmdTramite = new SqlCommand("INSERT INTO TramitesPasaporte (IdCiudadano, EstadoActual) VALUES (@id, 'En Proceso')", conn);
                    cmdTramite.Parameters.AddWithValue("@id", idPersona);
                    cmdTramite.ExecuteNonQuery();
                }
                return RedirectToAction("Inicio");
            }
            return View(datos);
        }

        public ActionResult Gestionar(int id)
        {
            Expediente exp = new Expediente();
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                string sql = "SELECT * FROM TramitesPasaporte t INNER JOIN Ciudadanos c ON t.IdCiudadano = c.IdCiudadano WHERE t.IdTramite = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    exp.IdTramite = Convert.ToInt32(dr["IdTramite"]);
                    exp.Nombres = dr["Nombres"].ToString();
                    exp.Apellidos = dr["Apellidos"].ToString();
                    exp.CedulaIdentidad = dr["CedulaIdentidad"].ToString();
                    exp.EstadoActual = dr["EstadoActual"].ToString();
                    exp.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    exp.Nacimiento = DateTime.Now;
                }
            }
            return View(exp);
        }

        [HttpPost]
        public ActionResult Gestionar(Expediente datos)
        {
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TramitesPasaporte SET EstadoActual = @st WHERE IdTramite = @id", con);
                cmd.Parameters.AddWithValue("@st", datos.EstadoActual);
                cmd.Parameters.AddWithValue("@id", datos.IdTramite);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio");
        }
    }
}