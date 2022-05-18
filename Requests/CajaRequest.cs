using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class CajaRequest : Caja
    {
        public List<Caja> list(string subdominio)
        {
            CajaService cajaService = new CajaService();
            List<Caja> cajas = new List<Caja>();
            cajas = cajaService.list(subdominio);
            return cajas;
        }

        public Caja get(string subdominio, string idCaja)
        {
            CajaService cajaService = new CajaService();
            Caja cajas = new Caja();
            cajas = cajaService.get(subdominio, idCaja);
            return cajas;
        }
    }
}