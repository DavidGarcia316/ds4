
namespace OficinaPasaportesWeb.Models {
 public class Passport {
  public int PassportId{get;set;}
  public int RequestId{get;set;}
  public PassportRequest Request{get;set;}
  public string NumeroPasaporte{get;set;}
  public DateTime FechaEmision{get;set;}
  public DateTime FechaExpiracion{get;set;}
 }
}