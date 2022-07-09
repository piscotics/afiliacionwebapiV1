using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarContratosRequest : SincronizarContratos
    {
       
        public SincronizarContratos get(string subdominio)
        {
            SincronizarContratosService sincronizarContratosService = new SincronizarContratosService();
            SincronizarContratos sincronizarContrato = new SincronizarContratos();
            sincronizarContrato = sincronizarContratosService.get(subdominio);
            return sincronizarContrato;
        }
    }
}