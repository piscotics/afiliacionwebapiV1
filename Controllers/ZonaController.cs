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
    [Route("api/zone")]
    public class ZonaController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult listaZonas([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            ZonaRequest zonaRequest = new ZonaRequest();
            return Ok(zonaRequest.list(subdominio));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Zona zona)
        {
            if (zona == null) return BadRequest();

            ZonaRequest zonaRequest = new ZonaRequest();
            Zona resultado = new Zona();

            resultado = zonaRequest.create(zona);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Zona zona)
        {
            if (zona == null) return BadRequest();

            ZonaRequest zonaRequest = new ZonaRequest();
            Zona resultado = new Zona();

            resultado = zonaRequest.update(zona);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string id, string subdominio)
        {
            if (id == "" || subdominio == "") return BadRequest();

            ZonaRequest zonaRequest = new ZonaRequest();
            Zona resultado = new Zona();

            resultado = zonaRequest.get(id, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}