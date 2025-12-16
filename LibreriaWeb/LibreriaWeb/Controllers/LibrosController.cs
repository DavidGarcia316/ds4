using System.Web.Mvc;
using System.Linq;
using LibreriaWeb.BaseDatos;
using LibreriaWeb.Models;

namespace LibreriaWeb.Controllers
{
    // 1. [Authorize] a nivel de clase:
    // Obliga a que el usuario esté logueado para entrar a CUALQUIER parte de este controlador.
    [Authorize]
    public class LibrosController : Controller
    {
        AccesoDatos db = new AccesoDatos();

        // ---------------------------------------------------------
        // SECCIÓN 1: INVENTARIO Y VENTAS (EXISTENTE)
        // ---------------------------------------------------------

        // GET: Inventario
        public ActionResult Index()
        {
            var libros = db.ObtenerLibros();
            return View(libros);
        }

        // GET: Vista para Vender
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult Vender()
        {
            ViewBag.Libros = new SelectList(db.ObtenerLibros(), "IdLibro", "Titulo");
            return View();
        }

        // POST: Procesar Venta
        [HttpPost]
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult Vender(string cliente, int idLibro, int cantidad)
        {
            string resultado = db.RegistrarVenta(cliente, idLibro, cantidad);
            TempData["Mensaje"] = resultado;
            return RedirectToAction("Index");
        }

        // GET: Reportes
        [Authorize(Roles = "Admin")]
        public ActionResult Reportes()
        {
            var libros = db.ObtenerLibros();
            var reporte = libros.GroupBy(l => l.Categoria)
                                .Select(g => new ReporteViewModel
                                {
                                    Categoria = g.Key,
                                    TotalStock = g.Sum(x => x.Stock),
                                    ValorInventario = g.Sum(x => x.Stock * x.Precio)
                                }).ToList();

            return View(reporte);
        }

        // ---------------------------------------------------------
        // SECCIÓN 2: ACCIONES PARA EL CLIENTE
        // ---------------------------------------------------------

        // Acción cuando el cliente da clic en "Comprar / Pedir"
        [Authorize(Roles = "Cliente")]
        public ActionResult Solicitar(int idLibro, string titulo)
        {
            if (Session["Usuario"] == null) return RedirectToAction("Login", "Acceso");

            string nombreUsuario = Session["Usuario"].ToString();
            bool exito = db.SolicitarLibro(0, nombreUsuario, idLibro, titulo);

            if (exito) TempData["Mensaje"] = "Solicitud enviada al vendedor";
            else TempData["Mensaje"] = "Error al solicitar";

            return RedirectToAction("Index");
        }

        // ---------------------------------------------------------
        // SECCIÓN 3: ACCIONES PARA EL VENDEDOR (PEDIDOS Y CLIENTES)
        // ---------------------------------------------------------

        // Ver la lista de pedidos pendientes
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult GestionarPedidos()
        {
            var pedidos = db.ObtenerPedidosPendientes();
            return View(pedidos);
        }

        // Procesar (Aprobar) un pedido específico
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult Aprobar(int idPedido, string cliente, int idLibro, int cantidad)
        {
            db.AprobarPedido(idPedido, cliente, idLibro, cantidad);
            TempData["Mensaje"] = "Pedido aprobado y stock descontado.";
            return RedirectToAction("GestionarPedidos");
        }

        // Vista para registrar nuevo cliente
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult NuevoCliente()
        {
            return View();
        }

        // POST: Guardar nuevo cliente
        [HttpPost]
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult NuevoCliente(string nombre, string email, string password)
        {
            bool resultado = db.RegistrarNuevoCliente(nombre, email, password);
            if (resultado) ViewBag.Mensaje = "Cliente registrado con éxito";
            else ViewBag.Error = "No se pudo registrar (quizás el email ya existe)";

            return View();
        }

        // ---------------------------------------------------------
        // SECCIÓN 4: AGREGAR NUEVO LIBRO (INGRESO DE MERCADERÍA)
        // ---------------------------------------------------------

        // GET: Mostrar formulario de nuevo libro
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Guardar el libro (Nuevo o Existente)
        [HttpPost]
        [Authorize(Roles = "Admin,Vendedor")]
        public ActionResult Nuevo(string titulo, string categoria, decimal precio, int stock)
        {
            bool exito = db.AgregarLibro(titulo, categoria, precio, stock);

            if (exito) TempData["Mensaje"] = "Libro registrado/actualizado con éxito";
            else TempData["Mensaje"] = "Error al registrar el libro";

            return RedirectToAction("Index");
        }
    }
}