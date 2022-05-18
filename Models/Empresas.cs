using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Empresas
    {
        public int idEmpresas { get; set; } // Utilizado para el ID original de la empresa, en caso de ser modificado
        public string nitEmpresa { get; set; }
        public string empresa { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }

        //public List<BaseDatos> listaBases { get; set; }
    }
}