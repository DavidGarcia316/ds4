class Program
{
    static void main(String[] args)
    {

        try
        {
            int[] MyNumbers = { 1, 2, 3 };
            Console.WriteLine(MyNumbers[10]);
        }
        catch (Exception e)
        {
            Console.WriteLine("algo salio mal, valide el indice del arreglo");
        }
        finally
        {
            Console.WriteLine("continuacion de la aplicacion iuego del bloque try/catch");
        }
    }
}