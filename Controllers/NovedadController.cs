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
    [Route("api/novelty")]
    public class NovedadController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            NovedadRequest novedadRequest = new NovedadRequest();
            return Ok(novedadRequest.list(subdominio));
        }
 
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idNovedad, string subdominio)
        {
            if (subdominio == "" || idNovedad == "") return BadRequest();

            NovedadRequest novedadRequest = new NovedadRequest();
            Novedad resultado = new Novedad();

            resultado = novedadRequest.get(subdominio, idNovedad);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
