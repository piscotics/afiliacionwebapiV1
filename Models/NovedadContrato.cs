using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
 public class NovedadContrato
 {

    public Int32 idNovedadContrato{ get; set; }
    public Int32 idNovedad { get; set; }
    public string idContrato { get; set; }
    public DateTime fechanovedad { get; set; }
    public Int32 postfechadodia { get; set; }
    public Int32 aplicada { get; set; }
    public DateTime fechan { get; set; }
    public string usuario { get; set; }
    public string idcobrador { get; set; }
    public string modulo { get; set; }
    public Int32 transac { get; set; }
    public DateTime fechaprogramada { get; set; }
    public string posicionx{ get; set; }
    public string posiciony { get; set; }
    public string titular { get; set; }
    public string observaciones { get; set; }
    public Int32 idalterna { get; set; }
    public string codRespuesta { get; set; }
    public string msjRespuesta { get; set; }
    public string subdominio { get; set; }
 }
}