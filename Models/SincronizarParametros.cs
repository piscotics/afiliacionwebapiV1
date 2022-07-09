using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarParametros
    {
        public Int32 Codigo { get; set; }
        public string Resultado { get; set; }
       
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}