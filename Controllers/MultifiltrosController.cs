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
    [Route("api/multifiltro")]
    public class MultifiltrosController : Controller
    {
     
               
        [HttpGet]
        [Route("list")]
        public IActionResult list([FromQuery] string subdominio, DateTime bfechaafiliaciondesde,DateTime bfechaafiliacionhasta, string bsucursal, string bcobrador, string bvendedor, string bzona, string bplan, string bempresa, string btipoafiliacion, string bestado)
        {
            if (subdominio == "") return BadRequest();

            MultifiltrosRequest multifiltrosRequest = new MultifiltrosRequest();
            return Ok(multifiltrosRequest.list( subdominio,  bfechaafiliaciondesde, bfechaafiliacionhasta,bsucursal,bcobrador,bvendedor,bzona,bplan,bempresa,btipoafiliacion,bestado));
        }
    }
}
