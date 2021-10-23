using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Usuario
    {
        public string username { get; set; }
        public string password { get; set; }
        public string idPersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string renovarPass { get; set; }
        public string estado { get; set; }
        public string cargo { get; set; }
        public string usuarioModif { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}