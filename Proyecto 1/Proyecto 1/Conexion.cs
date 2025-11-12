using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

public class Conexion
{
    private const string connectionString = "Data Source=DESKTOP - I219HIE\\MSSQLLocalDB;Initial Catalog=CalculadoraDB;Integrated Security=True;Connect Timeout=30";

    private readonly CultureInfo cultura = CultureInfo.InvariantCulture;

    /// <summary>
    /// </summary>
    /// <param name="sql">La sentencia SQL a ejecutar.</param>
    /// <returns>True si el comando fue exitoso, False si ocurrió un error.</returns>
    public bool EjecutarComando(string sql)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando SQL: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        } // La conexión se cierra aquí automáticamente.
    }

    /// <summary>
    /// </summary>
    /// <param name="sql">La sentencia SELECT a ejecutar.</param>
    /// <returns>Un DataTable con los resultados de la consulta.</returns>
    public DataTable ObtenerResultados(string sql)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener resultados SQL: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        return dt;
    }
}
