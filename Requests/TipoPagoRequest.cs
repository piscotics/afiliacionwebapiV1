using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class TipoPagoRequest : TipoPago
    {
        public List<TipoPago> list(string subdominio)
        {
            TipoPagoService tipoPagoService = new TipoPagoService();
            List<TipoPago> tipoPagos = new List<TipoPago>();
            tipoPagos = tipoPagoService.list(subdominio);
            return tipoPagos;
        }

        public TipoPago get(string subdominio, string idTipoPago)
        {
            TipoPagoService tipoPagoService = new TipoPagoService();
            TipoPago tipoPagos = new TipoPago();
            tipoPagos = tipoPagoService.get(subdominio, idTipoPago);
            return tipoPagos;
        }
    }
}