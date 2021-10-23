using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Contrato
    {
        public string idContrato { get; set; }
        public Titular titular { get; set; }
        public string tipoAfiliacion { get; set; }
        public DateTime fechaAfiliacion { get; set; }
        public string estatus { get; set; }
        public DateTime vigenciaDesde { get; set; }
        public DateTime vigenciaHasta { get; set; }
        public float valorCuota { get; set; }
        public int diaCobro { get; set; }
        public FormaPago formaPago { get; set; }
        public Plan plan { get; set; }
        public Zona zona { get; set; }
        public Sucursal sucursal { get; set; }
        public Empleado cobrador { get; set; }
        public Empleado vendedor { get; set; }
        public string direccionCobro { get; set; }
        public string observaciones { get; set; }
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}