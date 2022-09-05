using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarPagosRequest : SincronizarPagos
    {
       
        public SincronizarPagos get(string subdominio)
        {
            SincronizarPagosService sincronizarPagosService = new SincronizarPagosService();
            SincronizarPagos sincronizarPago = new SincronizarPagos();
            sincronizarPago = sincronizarPagosService.get(subdominio);
            return sincronizarPago;
        }
    }
}