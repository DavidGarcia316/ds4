class Program
{
    static void main(String[] args)
    {
        int num;

        Console.WriteLine("digite el numero deseado");

        try
        {
            num = Int16.Parse(Console.ReadLine());

        }
        catch (Exception ex)
        {
            Console.WriteLine("no se ha introducido un digito valido");
            num = -1;
        }
        Console.WriteLine(num);
    }
}