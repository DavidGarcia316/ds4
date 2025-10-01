//propiedades de lectura escritura
public class Empleado
{
    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
}
//propiedades con validacion
public class CuentaBancaria
{
    private decimal saldo;

    public decimal Saldo
    {
        get { return saldo; }
        set
        {
            if (value >= 0)
            {
                saldo = value;
            }
            else
            {
                throw new ArgumentException("El saldo no puede ser negativo.");
            }
        }
    }
}

//propiedades de solo lectura
public class Cobertura
{
    private double radio;

    public Cobertura(double radio)
    {
        this.radio = radio;
    }

    public double Radio
    {
        get { return radio; }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // El código de la imagen omite la definición de la clase 'Empleado',
        // pero se usa en el método Main.
        // Asumiendo una definición simple para que el Main compile:
        // class Empleado { public string Nombre { get; set; } }

        // Uso de una propiedad automática (asumiendo que Empleado tiene Nombre)
        // Empleado empleado = new Empleado(); // Necesita la clase Empleado
        // empleado.Nombre = "John Doe";
        // Console.WriteLine($"Nombre del empleado: {empleado.Nombre}");

        // Nota: La imagen tiene 'Empleado empleado = new Empleado();'
        // y 'empleado.Nombre = "John Doe";', pero el constructor y el campo
        // 'Nombre' de la clase 'Empleado' no se muestran en la imagen.
        // El resto del código principal:

        CuentaBancaria cta = new CuentaBancaria();
        cta.Saldo = 100;
        Console.WriteLine($"El saldo del empleado: {cta.Saldo}");

        //probar despues con un saldo negativo, para ver la excepcion
        // cta.Saldo = -10; // Esto lanzaría la excepción

        Cobertura c = new Cobertura(5);
        Console.WriteLine($"Con una cobertura de: {c.Radio}");
    }
}