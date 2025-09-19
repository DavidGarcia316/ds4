using System;

namespace Laboratorio33
{
    class CalculoPerimetro
    {
        public static double CalcularPerimetroRectangulo(double BRectangulo, double altura)
        {
            return 2 * (BRectangulo + altura);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la base del rectángulo:");
            double BRectangulo = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la altura del rectángulo:");
            double altura = double.Parse(Console.ReadLine());

            double perimetro = CalculoPerimetro.CalcularPerimetroRectangulo(BRectangulo, altura);

            Console.WriteLine($"El perímetro del rectángulo es: {perimetro:F2}");
        }
    }
}