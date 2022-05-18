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
    [Route("api/empresas")]
    public class EmpresasController : Controller
    {
        
        [HttpGet]
        [Route("list")]
        public IActionResult listaEmpresas([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            EmpresasRequest empresasRequest = new EmpresasRequest();
            return Ok(empresasRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            EmpresasRequest empRequest = new EmpresasRequest();
            Empresas resultado = new Empresas();

            resultado = empRequest.get(subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
