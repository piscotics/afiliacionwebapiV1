using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Requests
{
    public class ZonaRequest : Zona
    {
        public Zona create(Zona zona)
        {
            ZonaService zonaService = new ZonaService();
            return zonaService.create(zona);
        }

        public Zona update(Zona zona)
        {
            ZonaService zonaService = new ZonaService();
            return zonaService.update(zona);
        }

        public List<Zona> list(string subdominio)
        {
            ZonaService zonaService = new ZonaService();
            List<Zona> zonas = new List<Zona>();
            zonas = zonaService.list(subdominio);
            return zonas;
        }

        public Zona get(string idZona, string subdominio)
        {
            ZonaService zonaService = new ZonaService();
            Zona zonas = new Zona();
            zonas = zonaService.get(idZona, subdominio);
            return zonas;
        }
    }
}