using System;
class ClaseBase
{
    public void test()
    {
    }

    public void masTests()
    {
    }
}

class ClaseHijo : ClaseBase
{
    // Nota: El método 'masTests' de la clase base es 'sealed',
    // por lo tanto, no puede ser sobrescrito (override) en la clase hija.
    // El código en la imagen muestra un error de compilación.

    /*
    public override void masTests()
    {
    }
    */
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");
    }
}