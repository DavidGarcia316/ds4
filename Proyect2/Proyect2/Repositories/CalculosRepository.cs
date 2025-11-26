using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using WebAPI_Calculadora.Models;

namespace WebAPI_Calculadora.Repositories
{
    public class CalculosRepository
    {
        private readonly string connectionString;

        public CalculosRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CalculadoraDBConnection"].ConnectionString;
        }

        private CalculoHistorico ReaderToCalculo(SqlDataReader reader)
        {
            return new CalculoHistorico
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Operacion = reader.GetString(reader.GetOrdinal("Operacion")),
                Resultado = reader.GetDouble(reader.GetOrdinal("Resultado")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"))
            };
        }
        public List<CalculoHistorico> ObtenerTodos()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico ORDER BY Fecha DESC";
            return EjecutarConsulta(query);
        }

        public List<CalculoHistorico> ObtenerSumas()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico WHERE Operacion LIKE '% + %' ORDER BY Fecha DESC";
            return EjecutarConsulta(query);
        }

        public List<CalculoHistorico> ObtenerRestas()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico WHERE Operacion LIKE '% - %' ORDER BY Fecha DESC";
            return EjecutarConsulta(query);
        }
        public List<CalculoHistorico> ObtenerMultiplicaciones()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico WHERE Operacion LIKE '% * %' ORDER BY Fecha DESC";
            return EjecutarConsulta(query);
        }

        public List<CalculoHistorico> ObtenerDivisiones()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico WHERE Operacion LIKE '% / %' ORDER BY Fecha DESC";
            return EjecutarConsulta(query);
        }
        public List<CalculoHistorico> ObtenerResultadosGrandes()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico WHERE Resultado > 100 ORDER BY Fecha DESC";
            return EjecutarConsulta(query);
        }

        public void GuardarCalculo(CalculoNuevo calculo)
        {
           
            string query = "INSERT INTO CalculosHistorico (Operacion, Resultado) VALUES (@Operacion, @Resultado)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Operacion", calculo.Operacion);
                    command.Parameters.AddWithValue("@Resultado", calculo.Resultado);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private List<CalculoHistorico> EjecutarConsulta(string query)
        {
            List<CalculoHistorico> lista = new List<CalculoHistorico>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(ReaderToCalculo(reader));
                        }
                    }
                }
            }
            return lista;
        }
    }
}