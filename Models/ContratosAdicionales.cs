using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class ContratosAdicionales
    {

        public Int32 idca { get; set; }
        public string idcontrato { get; set; }
        public Int32 idsadicional { get; set; }
        public string servicioadicional { get; set; }
        public Int32  valor { get; set; }
        public string usuario { get; set; }
        public DateTime? fecha { get; set; }
        public string idpersona { get; set; }
        public float  valoranterior { get; set; }
        public DateTime? fecharetiro { get; set; }
        public string idasesor { get; set; }
        public string asesor { get; set; }
        public Int16 tipocobro { get; set; }

        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}