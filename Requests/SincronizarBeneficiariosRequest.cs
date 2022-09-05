using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarBeneficiariosRequest : SincronizarBeneficiarios
    {
       
        public SincronizarBeneficiarios get(string subdominio)
        {
            SincronizarBeneficiariosService sincronizarBeneficiariosService = new SincronizarBeneficiariosService();
            SincronizarBeneficiarios sincronizarBeneficiario = new SincronizarBeneficiarios();
            sincronizarBeneficiario = sincronizarBeneficiariosService.get(subdominio);
            return sincronizarBeneficiario;
        }
    }
}