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
    [Route("api/kinship")]
    public class ParentescoController : Controller
    {

        [HttpGet]
        [Route("list")]
        public IActionResult listaParentesco([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            ParentescoRequest parentescoRequest = new ParentescoRequest();
            return Ok(parentescoRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string idParentesco, string subdominio)
        {
            if (idParentesco == "" || subdominio == "") return BadRequest();

            ParentescoRequest parentescoRequest = new ParentescoRequest();
            Parentesco resultado = new Parentesco();

            resultado = parentescoRequest.get(idParentesco, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

    }
}
