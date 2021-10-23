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
    [Route("api/employee")]
    public class EmpleadoController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string tipoEmpleado, string subdominio)
        {
            if (tipoEmpleado == "" || subdominio == "") return BadRequest();

            EmpleadoRequest empleadoRequest = new EmpleadoRequest();
            return Ok(empleadoRequest.list(subdominio, tipoEmpleado));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idPersona, string subdominio)
        {
            if (idPersona == "" || subdominio == "") return BadRequest();

            EmpleadoRequest empleadoRequest = new EmpleadoRequest();
            Empleado resultado = new Empleado();

            resultado = empleadoRequest.get(subdominio, idPersona);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Empleado empleado)
        {
            if (empleado == null) return BadRequest();

            EmpleadoRequest empleadoRequest = new EmpleadoRequest();
            Empleado resultado = new Empleado();

            resultado = empleadoRequest.update(empleado);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Empleado empleado)
        {
            if (empleado == null) return BadRequest();

            EmpleadoRequest empleadoRequest = new EmpleadoRequest();
            Empleado resultado = new Empleado();

            resultado = empleadoRequest.create(empleado);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
