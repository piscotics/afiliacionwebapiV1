using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class BeneficiarioRequest : Beneficiario
    {

         public List<Beneficiario> list(string subdominio, string identificaciontitular, string idcontrato)
        {
           BeneficiarioService beneficiarioService = new BeneficiarioService();
            List<Beneficiario> beneficiario = new List<Beneficiario>();
            beneficiario = beneficiarioService.list(subdominio,identificaciontitular,idcontrato);
            return beneficiario;
        }

        public Beneficiario get(string subdominio, string identificacion)
        {
            BeneficiarioService BeneficiarioService = new BeneficiarioService();
            Beneficiario Beneficiario = new Beneficiario();
            Beneficiario = BeneficiarioService.get(subdominio, identificacion);
            return Beneficiario;
        }

        public Beneficiario update(Beneficiario persona)
        {
            BeneficiarioService BeneficiarioService = new BeneficiarioService();
            return BeneficiarioService.update(persona);
        }

        public Beneficiario create(Beneficiario persona)
        {
            BeneficiarioService BeneficiarioService = new BeneficiarioService();
            return BeneficiarioService.create(persona);
        }

    }
}