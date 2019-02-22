using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    public class WookieDataLayer
    {

        public List<Wookie> getAll()
        {
            List<Wookie> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Wookie.Include("Planete").ToList();
            }
            return list;
        }

        public void add(Wookie wookie)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Wookie.Add(wookie);
                context.SaveChanges();
            }
        }
        public void update(Wookie wookie)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Wookie.Add(wookie);
                context.Entry(wookie).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Wookie getById(int id)
        {
            Wookie unWookie = new Wookie();
            using (BDDEntities context = new BDDEntities())
            {
                unWookie = context.Wookie.Find(id);
            }
            return unWookie;
        }
        

    }
}
