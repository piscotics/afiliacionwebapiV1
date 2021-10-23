using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Plan
    {
        public string id { get; set; }
        public string nombrePlan { get; set; }
        public int estado { get; set; }
        public double valorBase { get; set; }
        public double valorAdicional { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}