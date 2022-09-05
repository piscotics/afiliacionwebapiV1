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
    [Route("api/sincronizarpagos")]
    public class SincronizarPagosController : Controller
    {
        

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery]  string subdominio)
        {
            if (subdominio == "" ) return BadRequest();

            SincronizarPagosRequest sincronizarPagosRequest = new SincronizarPagosRequest();
            SincronizarPagos resultado = new SincronizarPagos();

            resultado = sincronizarPagosRequest.get(subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
