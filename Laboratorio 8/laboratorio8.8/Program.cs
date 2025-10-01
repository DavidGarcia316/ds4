abstract class ClaseAbstracta
{
    //Se fuerza la herencia de la clase para definir estos metodos
    abstract protected string tomarValor();
    abstract public string prefixValor(string prefix);

    //método comun
    public void printOut()
    {
        Console.WriteLine(tomarValor());
    }
}

class ClaseConcreta1 : ClaseAbstracta
{
    protected override string tomarValor()
    {
        return "ClaseConcreta1";
    }

    public override string prefixValor(string prefix)
    {
        return $"{prefix}ClaseConcreta1";
    }
}
class ClaseConcreta2 : ClaseAbstracta
{
    protected override string tomarValor()
    {
        return "ClaseConcreta2";
    }

    public override string prefixValor(string prefix)
    {
        return $"{prefix}ClaseConcreta2";
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        ClaseConcreta1 concreta1 = new ClaseConcreta1();
        concreta1.printOut();
        Console.WriteLine(concreta1.prefixValor("ES_"));

        ClaseConcreta2 concreta2 = new ClaseConcreta2();
        concreta2.printOut();
        Console.WriteLine(concreta2.prefixValor("ES_"));


    }
}