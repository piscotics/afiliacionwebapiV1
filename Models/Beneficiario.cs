using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Beneficiario
    {
        public string identificacion { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public Parentesco idParentesco { get; set; }
        public DateTime fechaAfiliacion { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int edadAfiliacion { get; set; }
        public DateTime fechaCobertura { get; set; }
        public string observaciones { get; set; }
        public int adicional { get; set; }
    }
}