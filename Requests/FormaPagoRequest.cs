using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class FormaPagoRequest : FormaPago
    {
        public List<FormaPago> list(string subdominio)
        {
            FormaPagoService formaPagoService = new FormaPagoService();
            List<FormaPago> formaPagos = new List<FormaPago>();
            formaPagos = formaPagoService.list(subdominio);
            return formaPagos;
        }

        public FormaPago get(string subdominio, string idFormaPago)
        {
            FormaPagoService formaPagoService = new FormaPagoService();
            FormaPago formaPagos = new FormaPago();
            formaPagos = formaPagoService.get(subdominio, idFormaPago);
            return formaPagos;
        }
    }
}