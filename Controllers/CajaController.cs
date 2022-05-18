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
    [Route("api/cash")]
    public class CajaController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            CajaRequest cajaRequest = new CajaRequest();
            return Ok(cajaRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idCaja, string subdominio)
        {
            if (subdominio == "" || idCaja == "") return BadRequest();

            CajaRequest cajaRequest = new CajaRequest();
            Caja resultado = new Caja();

            resultado = cajaRequest.get(subdominio, idCaja);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
