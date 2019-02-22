using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    public class BatailleDataLayer
    {
        public List<Bataille> getAll()
        {
            List<Bataille> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Bataille.Include("Planete").ToList();
            }
            return list;
        }

        public void add(Bataille bataille)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Bataille.Add(bataille);
                context.SaveChanges();
            }
        }
        public void update(Bataille bataille)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Bataille.Add(bataille);
                context.Entry(bataille).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Bataille getById(int id)
        {
            Bataille uneBataille = new Bataille();
            using (BDDEntities context = new BDDEntities())
            {
                uneBataille = context.Bataille.Find(id);
            }
            return uneBataille;
        }
    }
}
