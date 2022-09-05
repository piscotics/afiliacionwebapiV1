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
    [Route("api/sincronizarusuarios")]
    public class SincronizarUsuariosController : Controller
    {
        

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery]  string subdominio)
        {
            if (subdominio == "" ) return BadRequest();

            SincronizarUsuariosRequest sincronizarUsuariosRequest = new SincronizarUsuariosRequest();
            SincronizarUsuarios resultado = new SincronizarUsuarios();

            resultado = sincronizarUsuariosRequest.get(subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
