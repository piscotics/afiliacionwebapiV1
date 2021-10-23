using afiliacionwebapi.Models;
using afiliacionwebapi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

namespace afiliacionwebapi.Controllers
{
    
    [ApiController]
    [Route("api/city")]
    public class MunicipioController : Controller
    {

        [HttpGet]
        [Route("list")]
        public IActionResult listaMunicipios([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            MunicipioRequest municipioRequest = new MunicipioRequest();
            return Ok(municipioRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idMunicipio, string subdominio)
        {
            if (idMunicipio == "" || subdominio == "") return BadRequest();

            MunicipioRequest municipioRequest = new MunicipioRequest();
            Municipio resultado = new Municipio();

            resultado = municipioRequest.get(idMunicipio, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

    }
}
