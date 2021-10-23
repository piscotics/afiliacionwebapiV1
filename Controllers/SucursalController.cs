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
    [Route("api/office")]
    public class SucursalesController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult listaZonas([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            SucursalRequest zonaRequest = new SucursalRequest();
            return Ok(zonaRequest.list(subdominio));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Sucursal sucursal)
        {
            if (sucursal == null) return BadRequest();

            SucursalRequest sucursalRequest = new SucursalRequest();
            Sucursal resultado = new Sucursal();

            resultado = sucursalRequest.create(sucursal);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Sucursal sucursal)
        {
            if (sucursal == null) return BadRequest();

            SucursalRequest sucursalRequest = new SucursalRequest();
            Sucursal resultado = new Sucursal();

            resultado = sucursalRequest.update(sucursal);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string id, string subdominio)
        {
            if (id == "" || subdominio == "") return BadRequest();

            SucursalRequest sucursalRequest = new SucursalRequest();
            Sucursal resultado = new Sucursal();

            resultado = sucursalRequest.get(id, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
