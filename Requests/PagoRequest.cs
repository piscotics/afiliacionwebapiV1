using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class PagoRequest : Pago
    {
        public Pago get(string subdominio, string NRORECIBO)
        {
            PagoService PagoService = new PagoService();
            Pago Pago = new Pago();
            Pago = PagoService.get(subdominio, NRORECIBO);
            return Pago;
        }

        public Pago update(Pago persona)
        {
            PagoService PagoService = new PagoService();
            return PagoService.update(persona);
        }
 
        public Pago create(Pago persona)
        {
            PagoService PagoService = new PagoService();
            return PagoService.create(persona);
        }

        public List<Pago> list(string subdominio, string identificaciontitular, string idcontrato)
        {
           PagoService pagoService = new PagoService();
            List<Pago> pago = new List<Pago>();
            pago = pagoService.list(subdominio,identificaciontitular,idcontrato);
            return pago;
        }

    }
}