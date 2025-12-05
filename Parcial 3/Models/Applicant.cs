
namespace OficinaPasaportesWeb.Models {
 public class Applicant{
  public int ApplicantId{get;set;}
  public string Cedula{get;set;}
  public string Nombre{get;set;}
  public string Apellido{get;set;}
  public DateTime FechaNacimiento{get;set;}
  public string Direccion{get;set;}
  public string Telefono{get;set;}
  public string Email{get;set;}
 }
}