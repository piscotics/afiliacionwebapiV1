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
    [Route("api/noveltycontract")]
    public class NovedadContratoController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            NovedadContratoRequest novedadContratoRequest = new NovedadContratoRequest();
            return Ok(novedadContratoRequest.list(subdominio));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(NovedadContrato novedadContrato)
        { 
            if (novedadContrato == null) return BadRequest(); 

            NovedadContratoRequest novedadContratoRequest = new NovedadContratoRequest();
            NovedadContrato resultado = new NovedadContrato();

            resultado = novedadContratoRequest.create(novedadContrato);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(NovedadContrato novedadContrato)
        {
            if (novedadContrato == null) return BadRequest();

            NovedadContratoRequest novedadContratoRequest = new NovedadContratoRequest();
            NovedadContrato resultado = new NovedadContrato();

            resultado = novedadContratoRequest.update(novedadContrato);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idNovedadContrato, string subdominio)
        {
            if (subdominio == "" || idNovedadContrato == "") return BadRequest();

            NovedadContratoRequest novedadContratoRequest = new NovedadContratoRequest();
            NovedadContrato resultado = new NovedadContrato();

            resultado = novedadContratoRequest.get(subdominio, idNovedadContrato);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
