﻿using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class ParentescoRequest : Parentesco
    {
        public Parentesco create(Parentesco parentesco)
        {
            ParentescoService parentescoService = new ParentescoService();
            return parentescoService.create(parentesco);
        }

        public Parentesco update(Parentesco parentesco)
        {
            ParentescoService parentescoService = new ParentescoService();
            return parentescoService.update(parentesco);
        }


        public List<Parentesco> list(string subdominio)
        {
            ParentescoService parentescoService = new ParentescoService();
            List<Parentesco> parentescos = new List<Parentesco>();
            parentescos = parentescoService.list(subdominio);
            return parentescos;
        }

        public Parentesco get(string idParentesco, string subdominio)
        {
            ParentescoService parentescoService = new ParentescoService();
            Parentesco parentescos = new Parentesco();
            parentescos = parentescoService.get(idParentesco, subdominio);
            return parentescos;
        }

    }
}