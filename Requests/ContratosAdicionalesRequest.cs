using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class ContratosAdicionalesRequest : ContratosAdicionales
    {
        public List<ContratosAdicionales> list(string subdominio,string identificaciontitular, string idcontrato)
        {
            ContratosAdicionalesService contratosAdicionalesService = new ContratosAdicionalesService();
            List<ContratosAdicionales> contratosAdicionaless = new List<ContratosAdicionales>();
            contratosAdicionaless = contratosAdicionalesService.list(subdominio,identificaciontitular,idcontrato );
            return contratosAdicionaless;
        }

        public ContratosAdicionales get(string subdominio, string idContratosAdicionales)
        {
            ContratosAdicionalesService contratosAdicionalesService = new ContratosAdicionalesService();
            ContratosAdicionales contratosAdicionaless = new ContratosAdicionales();
            contratosAdicionaless = contratosAdicionalesService.get(subdominio, idContratosAdicionales);
            return contratosAdicionaless;
        }

        public ContratosAdicionales update(ContratosAdicionales contratosAdicionales)
        {
            ContratosAdicionalesService ContratosAdicionalesService = new ContratosAdicionalesService();
            return ContratosAdicionalesService.update(contratosAdicionales);
        }

        public ContratosAdicionales create(ContratosAdicionales contratosAdicionales)
        {
            ContratosAdicionalesService ContratosAdicionalesService = new ContratosAdicionalesService();
            return ContratosAdicionalesService.create(contratosAdicionales);
        }
    }
}