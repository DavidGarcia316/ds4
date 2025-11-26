using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Calculadora.Models
{
    public class CalculoHistorico
    {
        public int Id { get; set; }
        public string Operacion { get; set; } 
        public double Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class CalculoNuevo
    {
        public string Operacion { get; set; }
        public double Resultado { get; set; }
    }
}