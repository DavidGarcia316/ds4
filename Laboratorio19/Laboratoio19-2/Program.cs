using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio19_2
{
    class Program
    {
        // Tu puerto correcto
        static string puerto = "44329";

        static void Main(string[] args)
        {
            Console.WriteLine("--- Laboratorio 19-2: Obtener todos los valores ---");
            GetItems();

            Console.WriteLine("\n--- Laboratorio 19-3: Obtener valor con ID 2 ---");
            GetItem(2);

            Console.ReadLine();
        }

        private static void GetItem(int id)
        {
            // CORRECCIÓN: Agregamos "/get" antes del ID
            var url = $"https://localhost:{puerto}/api/values/get/{id}";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine("Respuesta del Servidor (ID " + id + "):");
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void GetItems()
        {
            // CORRECCIÓN: Agregamos "/get" al final
            var url = $"https://localhost:{puerto}/api/values/get";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine("Respuesta del Servidor (Todos):");
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}