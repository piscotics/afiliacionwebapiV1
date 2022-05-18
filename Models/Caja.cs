using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Caja
    {
        public Int32 idCaja { get; set; }
        public string caja { get; set; }
        public Int32 estado { get; set; }

        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}