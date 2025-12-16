using System;

namespace LibreriaWeb.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCliente { get; set; }
        public int IdLibro { get; set; }
        public string TituloLibro { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}