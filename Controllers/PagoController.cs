using afiliacionwebapi.Models;
using afiliacionwebapi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afiliacionwebapi.Controllers
{
    [ApiController]
    [Route("api/benefi")]
    public class PagoController : Controller
    {
        
       /* [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string identificacion, string subdominio)
        {
            if (identificacion == "" || subdominio == "") return BadRequest();

            PagoRequest PagoRequest = new PagoRequest();
            Pago resultado = new Pago();

            resultado = PagoRequest.get(subdominio, identificacion);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Pago Pago)
        {
            if (Pago == null) return BadRequest();

            PagoRequest PagoRequest = new PagoRequest();
            Pago resultado = new Pago();

            resultado = PagoRequest.update(Pago);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Pago Pago)
        {
            if (Pago == null) return BadRequest();

            PagoRequest PagoRequest = new PagoRequest();
            Pago resultado = new Pago();

            resultado = PagoRequest.create(Pago);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }*/

    }
}
