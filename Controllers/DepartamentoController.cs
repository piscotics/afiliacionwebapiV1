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
    [Route("api/department")]
    public class DepartamentoController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult listaDepartamentos([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            DepartamentoRequest deptoRequest = new DepartamentoRequest();
            return Ok(deptoRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string codDepartamento, string subdominio)
        {
            if (codDepartamento == "" || subdominio == "") return BadRequest();

            DepartamentoRequest deptoRequest = new DepartamentoRequest();
            Departamento resultado = new Departamento();

            resultado = deptoRequest.get(codDepartamento, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("cities")]
        public IActionResult getCities([FromQuery] string codDepartamento, string subdominio)
        {
            if (codDepartamento == "" || subdominio == "") return BadRequest();

            MunicipioRequest municipioRequest = new MunicipioRequest();
            return Ok(municipioRequest.getCitiesDepartment(codDepartamento, subdominio));
        }
    }
}
