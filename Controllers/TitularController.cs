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
    [Route("api/contractor")]
    public class TitularController : Controller
    {
        
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string identificacion, string subdominio)
        {
            if (identificacion == "" || subdominio == "") return BadRequest();

            TitularRequest titularRequest = new TitularRequest();
            Titular resultado = new Titular();

            resultado = titularRequest.get(subdominio, identificacion);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Titular titular)
        {
            if (titular == null) return BadRequest();

            TitularRequest titularRequest = new TitularRequest();
            Titular resultado = new Titular();

            resultado = titularRequest.update(titular);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Titular titular)
        {
            if (titular == null) return BadRequest();

            TitularRequest titularRequest = new TitularRequest();
            Titular resultado = new Titular();

            resultado = titularRequest.create(titular);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

    }
}
