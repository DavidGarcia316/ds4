
using Microsoft.AspNetCore.Mvc;
using OficinaPasaportesWeb.Data;
using OficinaPasaportesWeb.Models;

namespace OficinaPasaportesWeb.Controllers {
 public class ApplicantsController:Controller{
   private readonly ApplicationDbContext _db;
   public ApplicantsController(ApplicationDbContext db){_db=db;}

   public IActionResult Index()=>View(_db.Applicants.ToList());
 }
}
