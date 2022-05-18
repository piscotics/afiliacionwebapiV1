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
    [Route("api/paymenttype")]
    public class TipoPagoController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            TipoPagoRequest tipoPagoRequest = new TipoPagoRequest();
            return Ok(tipoPagoRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idTipoPago, string subdominio)
        {
            if (subdominio == "" || idTipoPago == "") return BadRequest();

            TipoPagoRequest tipoPagoRequest = new TipoPagoRequest();
            TipoPago resultado = new TipoPago();

            resultado = tipoPagoRequest.get(subdominio, idTipoPago);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
