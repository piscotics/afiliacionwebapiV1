using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Pago
    {
        public string id { get; set; } // Utilizado para el ID original del beneficiario, en caso de ser modificado
       
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}