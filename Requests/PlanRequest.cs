using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class PlanRequest : Plan
    {
        public Plan create(Plan plan)
        {
            PlanService planService = new PlanService();
            return planService.create(plan);
        }

        public Plan update(Plan plan)
        {
            PlanService planService = new PlanService();
            return planService.update(plan);
        }

        public List<Plan> list(string subdominio)
        {
            PlanService planService = new PlanService();
            List<Plan> planes = new List<Plan>();
            planes = planService.list(subdominio);
            return planes;
        }

        public Plan get(string idPlan, string subdominio)
        {
            PlanService planService = new PlanService();
            Plan planes = new Plan();
            planes = planService.get(idPlan, subdominio);
            return planes;
        }
    }
}