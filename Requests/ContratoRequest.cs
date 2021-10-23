using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class ContratoRequest
    {
        public Contrato create(Contrato contrato)
        {
            ContratoService contratoService = new ContratoService();
            return contratoService.create(contrato);
        }

        public Contrato update(Contrato contrato)
        {
            ContratoService contratoService = new ContratoService();
            return contratoService.update(contrato);
        }

        public Contrato get(string subdominio, string idContrato)
        {
            ContratoService contratoService = new ContratoService();
            Contrato contrato = new Contrato();
            contrato = contratoService.get(subdominio, idContrato);
            return contrato;
        }

    }
}