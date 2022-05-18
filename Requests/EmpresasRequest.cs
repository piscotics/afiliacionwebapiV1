using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using afiliacionwebapi.Models;
using afiliacionwebapi.Services;

namespace afiliacionwebapi.Models
{
    public class EmpresasRequest : Empresas
    {
      
        public Empresas get(string subdominio)
        {
            EmpresasService empresasService = new EmpresasService();
            Empresas empresas = new Empresas();
            empresas = empresasService.get(subdominio);
            return empresas;
        }

          public List<Empresas> list(string subdominio)
        {
            EmpresasService empresasService = new EmpresasService();
            List<Empresas> empresas = new List<Empresas>();
            empresas = empresasService.list(subdominio);
            return empresas;
        }
    }
}