using System;

namespace matrizPatron
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            //Solicitar un valor par mayor o igual a 4
            do
            {
                Console.WriteLine("Ingrese el tamaño N de la matriz (debe ser par y >= 4):");
                n = int.Parse(Console.ReadLine());
            } while (n % 2 != 0 || n < 4);

            int[,] matriz = new int[n, n];
            Random rnd = new Random();
            int sumaTotal = 0;

            // Determinar las dos filas centrales
            int filaCentral1 = n / 2 - 1;
            int filaCentral2 = n / 2;

            // Llenar SOLO las dos filas centrales con valores aleatorios
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == filaCentral1 || i == filaCentral2) && j > 0 && j < n - 1)
                    {
                        matriz[i, j] = rnd.Next(101, 201);
                        sumaTotal += matriz[i, j];
                    }
                    else
                    {
                        matriz[i, j] = 0;
                    }
                }
            }

            //Imprimir la matriz
            Console.WriteLine("\nMatriz generada:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matriz[i, j].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }

            //Imprimir suma total
            Console.WriteLine($"\nSuma total de los elementos aleatorios: {sumaTotal}");
            Console.ReadKey(true);
        }
    }
}
