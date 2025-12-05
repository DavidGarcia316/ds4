
namespace OficinaPasaportesWeb.Models {
 public class PassportRequest {
  public int RequestId{get;set;}
  public int ApplicantId{get;set;}
  public Applicant Applicant{get;set;}
  public DateTime FechaSolicitud{get;set;}
  public int EstadoId{get;set;}
  public RequestStatus Estado{get;set;}
  public string TipoPasaporte{get;set;}
 }
}