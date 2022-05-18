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
    [Route("api/benefi")]
    public class BeneficiarioController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult listaParentesco([FromQuery] string subdominio, string identificaciontitular, string idcontrato)
        {
            if (subdominio == "") return BadRequest();

            BeneficiarioRequest BeneficiarioRequest = new BeneficiarioRequest();
            return Ok(BeneficiarioRequest.list(subdominio, identificaciontitular,  idcontrato));
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string identificacion, string subdominio)
        {
            if (identificacion == "" || subdominio == "") return BadRequest();

            BeneficiarioRequest BeneficiarioRequest = new BeneficiarioRequest();
            Beneficiario resultado = new Beneficiario();

            resultado = BeneficiarioRequest.get(subdominio, identificacion);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Beneficiario Beneficiario)
        {
            if (Beneficiario == null) return BadRequest();

            BeneficiarioRequest BeneficiarioRequest = new BeneficiarioRequest();
            Beneficiario resultado = new Beneficiario();

            resultado = BeneficiarioRequest.update(Beneficiario);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Beneficiario Beneficiario)
        {
            if (Beneficiario == null) return BadRequest();

            BeneficiarioRequest BeneficiarioRequest = new BeneficiarioRequest();
            Beneficiario resultado = new Beneficiario();

            resultado = BeneficiarioRequest.create(Beneficiario);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

    }
}
