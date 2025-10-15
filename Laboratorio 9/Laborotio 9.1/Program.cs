class Program
{
    static void Main()
    {
        decimal precio = SolicitarPrecio();
        string formaPago = SolicitarFormaDePago();

        if (formaPago == "tarjeta")
        {
            string numeroCuenta = SolicitarNumeroDeCuenta();
            MostrarConfirmacion(precio, formaPago, numeroCuenta);
        }
        else
        {
            MostrarConfirmacion(precio, formaPago);
        }
    }

    static decimal SolicitarPrecio()
    {
        Console.Write("Ingrese el precio del producto (valor positivo): ");
        decimal precio;

        while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
        {
            Console.Write("Por favor, ingrese un valor positivo para el precio: ");
        }

        return precio;
    }

    static string SolicitarFormaDePago()
    {
        Console.Write("Ingrese la forma de pago (efectivo o tarjeta): ");
        string formaPago = Console.ReadLine().ToLower();

        while (formaPago != "efectivo" && formaPago != "tarjeta")
        {
            Console.Write("Forma de pago inválida. Por favor, ingrese 'efectivo' o 'tarjeta' como forma de pago: ");
            formaPago = Console.ReadLine().ToLower();
        }

        return formaPago;
    }

    static string SolicitarNumeroDeCuenta()
    {
        Console.Write("Ingrese el número de cuenta (exactamente 16 dígitos): ");
        string numeroCuenta = Console.ReadLine();

        while (numeroCuenta.Length != 16 || !EsNumeroValido(numeroCuenta))
        {
            Console.Write("Número de cuenta inválido. Ingrese un número de 16 dígitos: ");
            numeroCuenta = Console.ReadLine();
        }

        return numeroCuenta;
    }

    // Método auxiliar para verificar si todos los caracteres de la cadena son dígitos
    static bool EsNumeroValido(string numero)
    {
        foreach (char c in numero)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    static void MostrarConfirmacion(decimal precio, string formaPago, string numeroCuenta = null)
    {
        Console.WriteLine($"\nPrecio del producto: {precio:C}");
        Console.WriteLine($"Forma de pago: {formaPago}");

        if (formaPago == "tarjeta" && numeroCuenta != null)
        {
            Console.WriteLine($"Número de cuenta: {numeroCuenta}");
        }
    }
}
