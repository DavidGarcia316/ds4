using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8._1
{
    class Persona
    {
        // Campo de cada objeto Persona que almacena su nombre
        public string Nombre;

        // Campo de cada objeto Persona que almacena su edad
        public int Edad;

        // Campo de cada objeto Persona que almacena su NIF
        public string NIF;

        //Incrementa en uno de edad del objeto Persona
        void Cumpleaños()
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
        // Campo de cada objeto Trabajador que almacena cuanto gana
        public int Sueldo;
        public Trabajador(string nombre, int edad, string nif, int sueldo)
            : base(nombre, edad, nif)
        {   // Inicializamos cada Trabajador en base al constructor de Persona
            Sueldo = sueldo;
        }
    }
}