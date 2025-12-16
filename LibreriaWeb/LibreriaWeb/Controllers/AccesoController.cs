using System.Web.Mvc;
using System.Web.Security; // Necesario para FormsAuthentication
using LibreriaWeb.BaseDatos;
using LibreriaWeb.Models;

namespace LibreriaWeb.Controllers
{
    public class AccesoController : Controller
    {
        AccesoDatos db = new AccesoDatos();

        // GET: Login (Muestra el formulario)
        public ActionResult Login()
        {
            return View();
        }

        // POST: Procesa los datos
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Usuario usuario = db.ValidarLogin(email, password);

            if (usuario != null)
            {
                // Crear la cookie de autenticación
                // Guardamos el ROL dentro de la cookie para usarlo después
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    email,
                    System.DateTime.Now,
                    System.DateTime.Now.AddMinutes(30),
                    false,
                    usuario.Rol, // <--- Aquí guardamos el Rol ('Admin', 'Cliente', etc.)
                    FormsAuthentication.FormsCookiePath);

                string hash = FormsAuthentication.Encrypt(ticket);
                System.Web.HttpCookie cookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, hash);
                Response.Cookies.Add(cookie);

                // Guardamos el nombre en sesión para mostrarlo en el saludo
                Session["Usuario"] = usuario.NombreCompleto;
                Session["Rol"] = usuario.Rol;

                return RedirectToAction("Index", "Libros");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}