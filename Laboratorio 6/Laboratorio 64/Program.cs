using System.ComponentModel.Design;

class Program
{
    static void checkAge(String[] args)
    {
        if (age < 18)
        {
            throw new ArithmeticException("acceso negado-no cumple con el criterio de edad");
        }
        else
        {
            Console.WriteLine("acceso concedido");
        }
    }
    static void main(string[] args)
    {
        checkAge(15);
    }
}