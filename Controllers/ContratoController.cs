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
    [Route("api/contract")]
    public class ContratoController : Controller
    {
        [HttpPost]
        [Route("create")]
        public IActionResult create(Contrato contrato)
        {
            if (contrato == null) return BadRequest();

            ContratoRequest contratoRequest = new ContratoRequest();
            Contrato resultado = new Contrato();

            resultado = contratoRequest.create(contrato);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Contrato contrato)
        {
            if (contrato == null) return BadRequest();

            ContratoRequest contratoRequest = new ContratoRequest();
            Contrato resultado = new Contrato();

            resultado = contratoRequest.update(contrato);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idContrato, string subdominio)
        {
            if (idContrato == "" || subdominio == "") return BadRequest();

            ContratoRequest contratoRequest = new ContratoRequest();
            Contrato resultado = new Contrato();

            resultado = contratoRequest.get(subdominio, idContrato);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
