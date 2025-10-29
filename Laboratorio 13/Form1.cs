using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System;

namespace Laboratorio13
{
    public partial class Form1 : Form
    {

        private string connectionString = @"Server=DESKTOP-I219HIE\BD2_DG;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("DESKTOP-I219HIE\\BD2_DG");
                conexion.Open();

                MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

                SqlCommand cmd = new SqlCommand("select ProductName from Products ", conexion);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Items.Add(reader.GetString(0));
                }
                
                conexion.Close();
                MessageBox.Show("Se cerró la conexión.");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
