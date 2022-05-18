using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Beneficiario
    {
        public string identificacion { get; set; }
        public string identificaciontitular { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string genero { get; set; }
        public DateTime? fechaCobertura { get; set; }
        public DateTime? fechaAfiliacion { get; set; }
        public string observaciones { get; set; }
        public Int64? edadAfiliacion { get; set; }
        public string idParentesco { get; set; }
        public string parentesco { get; set; }
        public int adicional { get; set; }
        public int fallecido { get; set; }
        public int retirado { get; set; }
        public DateTime? fechafallecido { get; set; }
        public DateTime? fecharetirado { get; set; }
        public string contrato { get; set; }
        public float valoradicional { get; set; }
        public string estadobeneficiario { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}