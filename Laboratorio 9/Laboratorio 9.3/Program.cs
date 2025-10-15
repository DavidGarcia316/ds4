class Aleatorios
{
    private Random random;
    public Aleatorios()
    {
        random = new Random();
    }

    // Método para generar un número aleatorio entre dos números
    public int GenerarNumeroEntre(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    // Método para generar un arreglo de números aleatorios entre dos números aleatorios
    public int[] GenerarArregloEntreNumerosAleatorios(int longitud)
    {
        // Generar los límites inferior y superior aleatorios
        int min = GenerarNumeroEntre(1, 100);  // Puedes ajustar el rango para los límites
        int max = GenerarNumeroEntre(min, 200); // max siempre será mayor o igual a min

        Console.WriteLine($"Generando arreglo entre {min} y {max}");

        // Crear y llenar el arreglo con números aleatorios entre min y max
        int[] arreglo = new int[longitud];
        for (int i = 0; i < longitud; i++)
        {
            arreglo[i] = GenerarNumeroEntre(min, max);
        }

        return arreglo;
    }
}

class Program
{
    static void Main()
    {
        // Crear una instancia de la clase Aleatorios
        Aleatorios aleatorios = new Aleatorios();

        // Generar un arreglo de 5 números aleatorios entre dos límites generados aleatoriamente
        int[] arregloNumeros = aleatorios.GenerarArregloEntreNumerosAleatorios(5);

        Console.WriteLine("Arreglo de números aleatorios generado entre dos límites aleatorios:");
        foreach (int n in arregloNumeros)
        {
            Console.WriteLine(n);
        }
    }
}
