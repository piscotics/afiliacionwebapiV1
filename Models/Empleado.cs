using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Empleado
    {
        public string id { get; set; } // Utilizado para el ID original del empleado, en caso de ser modificado
        public string idPersona { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }        
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public int estado { get; set; }
        public string tipoEmpleado { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}