using System;

namespace Laboratorio31
{
    class CalculosMatematicos
    {
        /*Metodo para calcular el valor solicitado en el documento*/
        public static int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }

    /*clase principal solicitada con nombre paara Program*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el primer número:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número:");
            int b = int.Parse(Console.ReadLine());

            int resultado = CalculosMatematicos.Calcular(a, b);

            Console.WriteLine($"El resultado de la operación (a + b) * (a - b) es: {resultado}");
        }
    }
}