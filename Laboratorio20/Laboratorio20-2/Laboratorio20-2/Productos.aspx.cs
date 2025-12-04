using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Laboratorio20_2
{
    public partial class Productos : System.Web.UI.Page
    {
        
        string connectionString = @"Server=(localdb)\MSSQLLocalDB; Database=productos; Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetearInterfaz();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            LimpiarCampos();

            // Usamos ViewState para recordar que estamos creando uno nuevo
            ViewState["EsNuevo"] = true;

            // Configuración de botones
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            // Bloquear búsqueda durante la edición
            txtBuscarId.Enabled = false;
            btnBuscar.Enabled = false;

            MostrarMensaje("Ingrese los datos y presione Guardar.", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool esNuevo = (ViewState["EsNuevo"] != null && (bool)ViewState["EsNuevo"]);
            string sql = "";

            if (esNuevo)
            {
                // INSERT (usando minusculas para tabla y columnas)
                sql = "insert into laptops (nombre, precio, stock) values (@nom, @pre, @sto)";
            }
            else
            {
                // UPDATE (usando minusculas)
                sql = "update laptops set nombre=@nom, precio=@pre, stock=@sto where id=@id";
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                // Parámetros
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);

                decimal precio;
                int stock;

                // Validación básica de tipos
                if (!decimal.TryParse(txtPrecio.Text, out precio)) precio = 0;
                if (!int.TryParse(txtStock.Text, out stock)) stock = 0;

                cmd.Parameters.AddWithValue("@pre", precio);
                cmd.Parameters.AddWithValue("@sto", stock);

                if (!esNuevo)
                {
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                }

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        string msg = esNuevo ? "Registro ingresado correctamente." : "Registro actualizado correctamente.";
                        MostrarMensaje(msg, true);
                        ResetearInterfaz();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error en base de datos: " + ex.Message, false);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ResetearInterfaz();
            MostrarMensaje("Operación cancelada.", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            string sql = "delete from laptops where id=@id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MostrarMensaje("Registro eliminado correctamente.", true);
                        ResetearInterfaz();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al eliminar: " + ex.Message, false);
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarId.Text))
            {
                MostrarMensaje("Ingrese un ID para buscar.", false);
                return;
            }

            string sql = "select id, nombre, precio, stock from laptops where id=@id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", txtBuscarId.Text);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Llenar datos encontrados
                        txtId.Text = reader["id"].ToString();
                        txtNombre.Text = reader["nombre"].ToString();
                        txtPrecio.Text = reader["precio"].ToString();
                        txtStock.Text = reader["stock"].ToString();

                        // Habilitar edición
                        HabilitarCampos(true);

                        // Ajustar botones para modo edición
                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnEliminar.Enabled = true;

                        txtBuscarId.Enabled = false;
                        btnBuscar.Enabled = false;

                        // Marcar que NO es nuevo (es edición)
                        ViewState["EsNuevo"] = false;

                        MostrarMensaje("Producto encontrado.", true);
                    }
                    else
                    {
                        MostrarMensaje("No se encontró ningún producto con ese ID.", false);
                        // No reseteamos todo para permitir buscar otro ID rapido
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error de conexión: " + ex.Message, false);
                }
            }
        }

        // Métodos de ayuda
        private void ResetearInterfaz()
        {
            LimpiarCampos();
            HabilitarCampos(false);

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;

            txtBuscarId.Enabled = true;
            txtBuscarId.Text = "";
            btnBuscar.Enabled = true;

            ViewState["EsNuevo"] = null;
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void HabilitarCampos(bool habilitar)
        {
            // ID siempre bloqueado (identity)
            txtNombre.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtStock.Enabled = habilitar;
        }

        private void MostrarMensaje(string texto, bool esExito)
        {
            lblMensaje.Text = texto;
            lblMensaje.Visible = true;
            if (esExito)
            {
                lblMensaje.CssClass = "mensaje exito";
            }
            else
            {
                lblMensaje.CssClass = "mensaje error";
            }
        }
    }
}