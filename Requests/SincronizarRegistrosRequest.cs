using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarRegistrosRequest : SincronizarRegistros
    {
       
        public SincronizarRegistros get(string subdominio)
        {
            SincronizarRegistrosService sincronizarRegistrosService = new SincronizarRegistrosService();
            SincronizarRegistros sincronizarRegistros = new SincronizarRegistros();
            sincronizarRegistros = sincronizarRegistrosService.get(subdominio);
            return sincronizarRegistros;
        }
    }
}