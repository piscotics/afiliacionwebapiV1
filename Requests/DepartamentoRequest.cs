using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Requests
{
    public class DepartamentoRequest : Departamento
    {
        public List<Departamento> list(string subdominio)
        {
            DepartamentoService deptoService = new DepartamentoService();
            List<Departamento> departamentos = new List<Departamento>();
            departamentos = deptoService.list(subdominio);
            return departamentos;
        }

        public Departamento get(string codDepartamento, string subdominio)
        {
            DepartamentoService deptoService = new DepartamentoService();
            Departamento departamentos = new Departamento();
            departamentos = deptoService.get(codDepartamento, subdominio);
            return departamentos;
        }
    }
}