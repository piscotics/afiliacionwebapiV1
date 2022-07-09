using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class TitularesBeneficiariosRequest : TitularesBeneficiarios
    {

         public List<TitularesBeneficiarios> list(string subdominio, string identificaciontitular, string idcontrato)
        {
           TitularesBeneficiariosService titularesBeneficiariosService = new TitularesBeneficiariosService();
            List<TitularesBeneficiarios> titularesBeneficiarios = new List<TitularesBeneficiarios>();
            titularesBeneficiarios = titularesBeneficiariosService.list(subdominio,identificaciontitular,idcontrato);
            return titularesBeneficiarios;
        }

        

    }
}