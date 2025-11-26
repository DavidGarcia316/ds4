using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI_Calculadora.Models;
using WebAPI_Calculadora.Repositories;

namespace WebAPI_Calculadora.Controllers
{
    [RoutePrefix("api/calculos")]
    public class CalculosController : ApiController
    {
        private readonly CalculosRepository _repository = new CalculosRepository();

        
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTodos()
        {
            List<CalculoHistorico> data = _repository.ObtenerTodos();
            return Ok(data);
        }

        [HttpGet]
        [Route("sumas")]
        public IHttpActionResult GetSumas()
        {
            List<CalculoHistorico> data = _repository.ObtenerSumas();
            return Ok(data);
        }

      
        [HttpGet]
        [Route("restas")]
        public IHttpActionResult GetRestas()
        {
            List<CalculoHistorico> data = _repository.ObtenerRestas();
            return Ok(data);
        }

       
        [HttpGet]
        [Route("multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            List<CalculoHistorico> data = _repository.ObtenerMultiplicaciones();
            return Ok(data);
        }

        [HttpGet]
        [Route("divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            List<CalculoHistorico> data = _repository.ObtenerDivisiones();
            return Ok(data);
        }

       
        [HttpGet]
        [Route("grandes")]
        public IHttpActionResult GetResultadosGrandes()
        {
            List<CalculoHistorico> data = _repository.ObtenerResultadosGrandes();
            return Ok(data);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostCalculo([FromBody] CalculoNuevo calculo)
        {
            if (calculo == null || string.IsNullOrWhiteSpace(calculo.Operacion))
            {
                return BadRequest("Datos de cálculo inválidos.");
            }

            try
            {
                _repository.GuardarCalculo(calculo);
                return Ok("Cálculo guardado con éxito.");
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}