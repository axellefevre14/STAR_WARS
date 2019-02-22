using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    class PlaneteDataLayer
    {
        public List<Planete> getAll()
        {
            List<Planete> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Planete.ToList();
            }
            return list;
        }

        public void add(Planete planete)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Planete.Add(planete);
                context.SaveChanges();
            }
        }
        public void update(Planete planete)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Planete.Add(planete);
                context.Entry(planete).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Planete getById(int id)
        {
            Planete unePlanete = new Planete();
            using (BDDEntities context = new BDDEntities())
            {
                unePlanete = context.Planete.Find(id);
            }
            return unePlanete;
        }

    }
}
