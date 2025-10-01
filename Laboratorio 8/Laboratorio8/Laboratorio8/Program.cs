
using System;
namespace Laboratorio8;
// Definición de la clase Persona
class Persona
{
    // Campo de cada objeto Persona que almacena su nombre
    public string Nombre;
    // Campo de cada objeto Persona que almacena su edad
    public int Edad;
    // Campo de cada objeto Persona que almacena su NIF
    public string NIF;

    void Cumpleaños() // Incrementa en uno de edad del objeto Persona
    {
        Edad++;
    }

    // Constructor de Persona
    public Persona(string nombre, int edad, string nif)
    {
        Nombre = nombre;
        Edad = edad;
        NIF = nif;
    }
}
class Trabajador : Persona
{
    // Campo de cada objeto Trabajador que almacena cuánto gana
    public int Sueldo;

    public Trabajador(string nombre, int edad, string nif, int sueldo)
        : base(nombre, edad, nif)
    {
        // Inicializamos cada Trabajador en base al constructor de Persona
        Sueldo = sueldo;
    }
}

// Y desde el programa principal:
class Program
{
    public static void Main()
    {
        Trabajador p = new Trabajador("Josan", 22, "77588260-Z", 100000);
        Console.WriteLine("Nombre=" + p.Nombre);
        Console.WriteLine("Edad=" + p.Edad);
        Console.WriteLine("NIF=" + p.NIF);
        Console.WriteLine("Sueldo=" + p.Sueldo);
        Console.ReadKey();
    }
}
