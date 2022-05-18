using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class NovedadRequest : Novedad
    {
        public List<Novedad> list(string subdominio)
        {
            NovedadService novedadService = new NovedadService();
            List<Novedad> novedades = new List<Novedad>();
            novedades = novedadService.list(subdominio);
            return novedades;
        }

        public Novedad get(string subdominio, string idNovedad)
        {
            NovedadService novedadService = new NovedadService();
            Novedad novedades = new Novedad();
            novedades = novedadService.get(subdominio, idNovedad);
            return novedades;
        }
    }
}