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
    [Route("api/serviceadicional")]
    public class ServiciosAdicionalesController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string tipoServicio ,string subdominio)
        {
            if (tipoServicio == "" || subdominio == "") return BadRequest();

            ServiciosAdicionalesRequest ServiciosAdicionalesRequest = new ServiciosAdicionalesRequest();
            return Ok(ServiciosAdicionalesRequest.list(subdominio,tipoServicio));
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idServiciosAdicionales, string subdominio)
        {
            if (idServiciosAdicionales == "" || subdominio == "") return BadRequest();

            ServiciosAdicionalesRequest ServiciosAdicionalesRequest = new ServiciosAdicionalesRequest();
            ServiciosAdicionales resultado = new ServiciosAdicionales();

            resultado = ServiciosAdicionalesRequest.get(subdominio, idServiciosAdicionales);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        

    }
}
