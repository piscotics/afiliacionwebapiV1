using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Novedad
    {
        public Int32 idNovedad{ get; set; }
        public string codigo { get; set; }
        public string novedad { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}