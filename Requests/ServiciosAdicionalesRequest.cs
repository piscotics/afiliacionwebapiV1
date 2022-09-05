using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class ServiciosAdicionalesRequest : ServiciosAdicionales
    {
        public List<ServiciosAdicionales> list(string subdominio, string tipoServicio)
        {
            ServiciosAdicionalesService serviciosAdicionalesService = new ServiciosAdicionalesService();
            List<ServiciosAdicionales> serviciosAdicionales = new List<ServiciosAdicionales>();
            serviciosAdicionales = serviciosAdicionalesService.list(subdominio,tipoServicio);
            return serviciosAdicionales;
        }

        public ServiciosAdicionales get(string subdominio, string idServiciosAdicionales)
        {
            ServiciosAdicionalesService serviciosAdicionalesService = new ServiciosAdicionalesService();
            ServiciosAdicionales serviciosAdicionales = new ServiciosAdicionales();
            serviciosAdicionales = serviciosAdicionalesService.get(subdominio, idServiciosAdicionales);
            return serviciosAdicionales;
        }
    }
}