internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, suma;

        Console.WriteLine("Ingrese el primer nmero:");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo nmero:");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        suma = primerNumero + segundoNumero;

        Console.WriteLine("La suma de {0} y {1} es: {2}", primerNumero, segundoNumero, suma);
    }
}