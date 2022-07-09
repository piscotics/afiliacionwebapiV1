using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class ServiciosAdicionales
    {

        public Int32 idsa { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public float valor { get; set; }
        public Int16 tipocobro { get; set; }
        public string planproteccion { get; set; }
        public string parentesco { get; set; }
        public string usuario { get; set; }
        public float  valorpoliza { get; set; }
        public Int16 seguro { get; set; }
        public string tipo { get; set; }
       

        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}