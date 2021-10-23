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
    [Route("api/business")]
    public class EmpresaController : Controller
    {
        
        [HttpPut]
        [Route("update")]
        public IActionResult update(Empresa emp)
        {
            if (emp == null ) return BadRequest();

            EmpresaRequest empRequest = new EmpresaRequest();
            Empresa empresa = new Empresa();
            empresa = empRequest.update(emp);

            if (empresa == null || empresa.codRespuesta == "401") return Unauthorized();
            if (empresa.codRespuesta == "404") return BadRequest(empresa.msjRespuesta);
            
            return Ok(empresa);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            EmpresaRequest empRequest = new EmpresaRequest();
            Empresa resultado = new Empresa();

            resultado = empRequest.get(subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
