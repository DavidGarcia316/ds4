using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_1
{
    internal class Conexion
    {
        public SqlConnection conectar()
        {
            try
            {
                SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-I219HIE\\BD2_DG;Initial Catalog=DB_Calculadora;Integrated Security=True");
                conexion.Open();
                MessageBox.Show("Conexion Exitosa");
                return conexion;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de conexion: " + e.Message);
                return null;
            }
        }
    }
}
