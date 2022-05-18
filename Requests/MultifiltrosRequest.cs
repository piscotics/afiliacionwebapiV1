using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class MultifiltrosRequest
    {
      
        public List<Contrato> list(string subdominio,  DateTime bfechaafiliaciondesde,DateTime bfechaafiliacionhasta, string bsucursal, string bcobrador, string bvendedor, string bzona, string bplan, string bempresa, string btipoafiliacion, string bestado)
        {
            MultifiltrosService multifiltrosService = new MultifiltrosService();
            List<Contrato> contratos = new List<Contrato>();
            contratos = multifiltrosService.list(subdominio, bfechaafiliaciondesde, bfechaafiliacionhasta,bsucursal,bcobrador,bvendedor,bzona,bplan,bempresa,btipoafiliacion,bestado);
            return contratos;
        }

    }
}