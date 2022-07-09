using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class NovedadContratoRequest : NovedadContrato
    {
        public List<NovedadContrato> list(string subdominio, string idcontrato)
        {
            NovedadContratoService novedadContratoService = new NovedadContratoService();
            List<NovedadContrato> novedadesContrato = new List<NovedadContrato>();
            novedadesContrato = novedadContratoService.list(subdominio, idcontrato);
            return novedadesContrato;
        } 

        public NovedadContrato get(string subdominio, string idNovedadContrato)
        {
            NovedadContratoService novedadContratoService = new NovedadContratoService();
            NovedadContrato novedadesContrato = new NovedadContrato();
            novedadesContrato = novedadContratoService.get(subdominio, idNovedadContrato);
            return novedadesContrato;
        }
        public NovedadContrato create(NovedadContrato novedadContrato)
        {
            NovedadContratoService novedadContratoService = new NovedadContratoService();
            return novedadContratoService.create(novedadContrato);
        }

        public NovedadContrato update(NovedadContrato novedadContrato)
        {
            NovedadContratoService novedadContratoService = new NovedadContratoService();
            return novedadContratoService.update(novedadContrato);
        }
    }
}