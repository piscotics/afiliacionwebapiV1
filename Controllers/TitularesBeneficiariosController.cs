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
    [Route("api/titularesbeneficiarios")]
    public class TitularesBeneficiariosController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IActionResult listaTitularesBeneficiarios([FromQuery] string subdominio, string identificaciontitular, string idcontrato)
        {
            if (subdominio == "") return BadRequest();

            TitularesBeneficiariosRequest TitularesBeneficiariosRequest = new TitularesBeneficiariosRequest();
            return Ok(TitularesBeneficiariosRequest.list(subdominio, identificaciontitular,  idcontrato));
        }
        
        

    }
}
