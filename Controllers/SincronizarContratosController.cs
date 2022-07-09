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
    [Route("api/sincronizarcontratos")]
    public class SincronizarContratosController : Controller
    {
        

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery]  string subdominio)
        {
            if (subdominio == "" ) return BadRequest();

            SincronizarContratosRequest sincronizarContratosRequest = new SincronizarContratosRequest();
            SincronizarContratos resultado = new SincronizarContratos();

            resultado = sincronizarContratosRequest.get(subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
