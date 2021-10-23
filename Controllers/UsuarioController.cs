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
    [Route("api/user")]
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("login")]
        public IActionResult login(UsuarioRequest login)
        {
            if(login == null) return BadRequest();

            bool isCredentialValid = false;

            UsuarioRequest userRequest = new UsuarioRequest();
            Usuario usuario = new Usuario();
            usuario = userRequest.login(login.username, login.password, login.subdominio);
            
            if (usuario == null || usuario.codRespuesta == "401") return Unauthorized();
            if (usuario.codRespuesta == "404") return BadRequest(usuario.msjRespuesta);
            if (usuario.nombre != null) isCredentialValid = true;

            if (isCredentialValid)
            {
                /*
                 * Proceso de Generación de Token
                 * var token = TokenGenerator.GenerateTokenJwt(login.username);
                 * return Ok(token);
                */
                return Ok(usuario);
            } else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(Usuario usuario)
        {
            if (usuario == null) return BadRequest();

            UsuarioRequest userRequest = new UsuarioRequest();
            Usuario resultado = new Usuario();

            resultado = userRequest.create(usuario);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update(Usuario usuario)
        {
            if (usuario == null) return BadRequest();

            UsuarioRequest userRequest = new UsuarioRequest();
            Usuario resultado = new Usuario();

            resultado = userRequest.update(usuario);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult listaUsuarios([FromQuery] string subdominio)
        {
            if (subdominio == "") return BadRequest();

            UsuarioRequest usuarioRequest = new UsuarioRequest();
            return Ok(usuarioRequest.list(subdominio));
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get([FromQuery] string username, string subdominio)
        {
            if (username == "" || subdominio == "") return BadRequest();

            UsuarioRequest usuarioRequest = new UsuarioRequest();
            Usuario resultado = new Usuario();

            resultado = usuarioRequest.get(username, subdominio);

            if (resultado == null || resultado.codRespuesta == "401") return Unauthorized();
            if (resultado.codRespuesta == "404") return BadRequest(resultado.msjRespuesta);

            return Ok(resultado);
        }
    }
}
