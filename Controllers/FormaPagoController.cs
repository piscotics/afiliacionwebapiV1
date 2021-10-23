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
    [Route("api/paymentmethod")]
    public class FormaPagoController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            FormaPagoRequest formaPagoRequest = new FormaPagoRequest();
            return Ok(formaPagoRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idFormaPago, string subdominio)
        {
            if (subdominio == "" || idFormaPago == "") return BadRequest();

            FormaPagoRequest formaPagoRequest = new FormaPagoRequest();
            FormaPago resultado = new FormaPago();

            resultado = formaPagoRequest.get(subdominio, idFormaPago);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
