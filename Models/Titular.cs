using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Titular
    {
        public string id { get; set; } // Utilizado para el ID original del titular, en caso de ser modificado
        public string identificacion { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        //public string idDepartamento { get; set; }
        public Departamento departamento {get; set;}
        //public string idMunicipio { get; set; }
        public Municipio municipio { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public string telefono { get; set; }
        public string celular1 { get; set; }
        public string celular2 { get; set; }
        public string email { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public int edadAfiliacion { get; set; }
        public string genero { get; set; }
        public DateTime? fechaCobertura { get; set; }
        public DateTime? fechaAfiliacion { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}