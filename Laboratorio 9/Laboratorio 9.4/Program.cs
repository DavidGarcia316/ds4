using System;
using System.Collections.Generic;

class Aleatorios
{
    private Random random;
    public Aleatorios()
    {
        random = new Random();
    }
    public int GenerarNumeroEntre(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    public int[] GenerarArregloNoRepetidoEntreNumerosAleatorios(int longitud)
    {
        // Generar los límites inferior y superior aleatorios
        int min = GenerarNumeroEntre(1, 100);
        int max = GenerarNumeroEntre(min, 200);

        Console.WriteLine($"Generando arreglo no repetido entre {min} y {max}");

        if (longitud > (max - min + 1))
        {
            throw new ArgumentException("La longitud del arreglo no puede ser mayor al rango de números posibles.");
        }

        HashSet<int> numerosGenerados = new HashSet<int>();

        while (numerosGenerados.Count < longitud)
        {
            int numero = GenerarNumeroEntre(min, max);
            numerosGenerados.Add(numero);
        }
        return new int[numerosGenerados.Count];
    }
}

class Program
{
    static void Main()
    {
        Aleatorios aleatorios = new Aleatorios();

        // Generar un arreglo de 5 números aleatorios no repetidos entre dos límites generados aleatoriamente
        int[] arregloNumeros = aleatorios.GenerarArregloNoRepetidoEntreNumerosAleatorios(5);

        Console.WriteLine("Arreglo de números aleatorios no repetidos generado entre dos límites aleatorios:");
        foreach (int n in arregloNumeros)
        {
            Console.WriteLine(n);
        }
    }
}
