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
    [Route("api/contractadicional")]
    public class ContratosAdicionalesController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio, string identificaciontitular, string idcontrato)
        {
            if (subdominio == "") return BadRequest();

            ContratosAdicionalesRequest ContratosAdicionalesRequest = new ContratosAdicionalesRequest();
            return Ok(ContratosAdicionalesRequest.list(subdominio, identificaciontitular,  idcontrato));
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idContratosAdicionales, string subdominio)
        {
            if (idContratosAdicionales == "" || subdominio == "") return BadRequest();

            ContratosAdicionalesRequest ContratosAdicionalesRequest = new ContratosAdicionalesRequest();
            ContratosAdicionales resultado = new ContratosAdicionales();

            resultado = ContratosAdicionalesRequest.get(subdominio, idContratosAdicionales);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(ContratosAdicionales ContratosAdicionales)
        {
            if (ContratosAdicionales == null) return BadRequest();

            ContratosAdicionalesRequest ContratosAdicionalesRequest = new ContratosAdicionalesRequest();
            ContratosAdicionales resultado = new ContratosAdicionales();

            resultado = ContratosAdicionalesRequest.update(ContratosAdicionales);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(ContratosAdicionales ContratosAdicionales)
        {
            if (ContratosAdicionales == null) return BadRequest();

            ContratosAdicionalesRequest ContratosAdicionalesRequest = new ContratosAdicionalesRequest();
            ContratosAdicionales resultado = new ContratosAdicionales();

            resultado = ContratosAdicionalesRequest.create(ContratosAdicionales);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

    }
}
