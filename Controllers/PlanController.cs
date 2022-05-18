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
    [Route("api/plan")]
    public class PlanController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            PlanRequest planRequest = new PlanRequest();
            return Ok(planRequest.list(subdominio));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Plan plan)
        {
            if (plan == null) return BadRequest();

            PlanRequest planRequest = new PlanRequest();
            Plan resultado = new Plan();

            resultado = planRequest.create(plan);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Plan plan)
        {
            if (plan == null) return BadRequest();

            PlanRequest planRequest = new PlanRequest();
            Plan resultado = new Plan();

            resultado = planRequest.update(plan);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string id, string subdominio)
        {
            if (id == "" || subdominio == "") return BadRequest();

            PlanRequest planRequest = new PlanRequest();
            Plan resultado = new Plan();

            resultado = planRequest.get(id, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        
    }
}