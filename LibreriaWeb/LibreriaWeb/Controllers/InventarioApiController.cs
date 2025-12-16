using System.Web.Http;
using LibreriaWeb.BaseDatos; // <--- Referencia corregida
using System.Linq;

namespace LibreriaWeb.Controllers
{
    public class InventarioApiController : ApiController
    {
        AccesoDatos db = new AccesoDatos();

        public IHttpActionResult Get(int id)
        {
            var libros = db.ObtenerLibros();
            var libro = libros.FirstOrDefault(l => l.IdLibro == id);

            if (libro == null) return NotFound();

            return Ok(new
            {
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                StockActual = libro.Stock,
                Disponible = libro.Stock > 0
            });
        }
    }
}