using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using afiliacionwebapi.Models;
using afiliacionwebapi.Services;

namespace afiliacionwebapi.Models
{
    public class EmpresaRequest : Empresa
    {
        public Empresa update(Empresa emp)
        {
            EmpresaService empresaService = new EmpresaService();
            Empresa empresa = new Empresa();
            empresa = empresaService.update(emp);
            return empresa;
        }

        public Empresa get(string subdominio)
        {
            EmpresaService empresaService = new EmpresaService();
            Empresa empresa = new Empresa();
            empresa = empresaService.get(subdominio);
            return empresa;
        }
    }
}