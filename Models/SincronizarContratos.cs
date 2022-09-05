using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarContratos
    {
        public string Codigo { get; set; }
        public string Resultado { get; set; }
       
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}