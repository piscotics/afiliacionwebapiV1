using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class TitularRequest : Titular
    {
        public Titular get(string subdominio, string identificacion)
        {
            TitularService titularService = new TitularService();
            Titular titular = new Titular();
            titular = titularService.get(subdominio, identificacion);
            return titular;
        }

        public Titular update(Titular persona)
        {
            TitularService titularService = new TitularService();
            return titularService.update(persona);
        }

        public Titular create(Titular persona)
        {
            TitularService titularService = new TitularService();
            return titularService.create(persona);
        }

    }
}