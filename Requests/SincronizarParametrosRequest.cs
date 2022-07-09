using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarParametrosRequest : SincronizarParametros
    {
       
        public SincronizarParametros get(string subdominio)
        {
            SincronizarParametrosService sincronizarParametrosService = new SincronizarParametrosService();
            SincronizarParametros sincronizarParametro = new SincronizarParametros();
            sincronizarParametro = sincronizarParametrosService.get(subdominio);
            return sincronizarParametro;
        }

         
    }
}