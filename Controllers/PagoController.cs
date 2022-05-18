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
    [Route("api/payment")]
    public class PagoController : Controller
    {

        [HttpGet]
        [Route("list")]
        public IActionResult listaPagos([FromQuery] string subdominio, string identificacion, string idcontrato)
        {
            if (subdominio == "") return BadRequest();

            PagoRequest pagoRequest = new PagoRequest();
            return Ok(pagoRequest.list(subdominio, identificacion,  idcontrato));
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string NRORECIBO, string subdominio)
        {
            if (NRORECIBO == "" || subdominio == "") return BadRequest();

            PagoRequest pagoRequest = new PagoRequest();
            Pago resultado = new Pago();

            resultado = pagoRequest.get(subdominio, NRORECIBO);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Pago Pago)
        {
            if (Pago == null) return BadRequest();

            PagoRequest pagoRequest = new PagoRequest();
            Pago resultado = new Pago();

            resultado = pagoRequest.update(Pago);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Pago Pago)
        {
            if (Pago == null) return BadRequest();

            PagoRequest pagoRequest = new PagoRequest();
            Pago resultado = new Pago();

            resultado = pagoRequest.create(Pago);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

    }
}
