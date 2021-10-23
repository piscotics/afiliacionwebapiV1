using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Requests
{
    public class MunicipioRequest : Municipio
    {
        public List<Municipio> list(string subdominio)
        {
            MunicipioService municipioService = new MunicipioService();
            List<Municipio> municipios = new List<Municipio>();
            municipios = municipioService.list(subdominio);
            return municipios;
        }

        public Municipio get(string idMunicipio, string subdominio)
        {
            MunicipioService municipioService = new MunicipioService();
            Municipio municipios = new Municipio();
            municipios = municipioService.get(idMunicipio, subdominio);
            return municipios;
        }

        public List<Municipio> getCitiesDepartment(string codDepartamento, string subdominio)
        {
            MunicipioService municipioService = new MunicipioService();
            List<Municipio> municipios = new List<Municipio>();
            municipios = municipioService.getCitiesDepartment(codDepartamento, subdominio);
            return municipios;
        }
    }
}