using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    class DroideDataLayer
    {

        public List<Droide> getAll()
        {
            List<Droide> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Droide.Include("Type").ToList();
            }
            return list;
        }

        public void add(Droide droide)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Droide.Add(droide);
                context.SaveChanges();
            }
        }
        public void update(Droide droide)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Droide.Add(droide);
                context.Entry(droide).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Droide getById(int id)
        {
            Droide unDroide = new Droide();
            using (BDDEntities context = new BDDEntities())
            {
                unDroide = context.Droide.Find(id);
            }
            return unDroide;
        }

    }
}
