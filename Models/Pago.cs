using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class Pago
    {
        
      //  public string idpago { get; set; }
        public string nrorecibo { get; set; } 
        public DateTime fecha { get; set; } 
        public float valor { get; set; } 
        public float descuento { get; set; } 
        public bool anulado { get; set; } 
        public string idcobrador { get; set; } 
        public string cobrador { get; set; } 
        public string observaciones { get; set; } 
        public DateTime? cuotadesde { get; set; } 
        public DateTime? cuotahasta { get; set; } 
        public string nrofactura { get; set; } 
        public int idcaja { get; set; } 
        public string caja { get; set; } 
        public int idtipopago { get; set; } 
        public string tipopago { get; set; } 
        public string identificaciontitular { get; set; } 
        public string contrato { get; set; } 
        public string usuario { get; set; } 
        public string nota1 { get; set; } 
        public string nota2 { get; set; } 
        public DateTime? pagohasta { get; set; } 
        public string estadopago { get; set; }        
        public string codRespuesta { get; set; }
        public string msjRespuesta { get; set; }
        public string subdominio { get; set; }
    }
}