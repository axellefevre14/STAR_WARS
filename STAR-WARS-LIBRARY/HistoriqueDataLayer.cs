using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    public class HistoriqueDataLayer
    {
        public List<Historique> getAll()
        {
            List<Historique> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Historique.ToList();
            }
            return list;
        }

        public void add(Historique historique)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Historique.Add(historique);
                context.SaveChanges();
            }
        }
        public void update(Historique historique)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Historique.Add(historique);
                context.Entry(historique).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Historique getById(int id)
        {
            Historique uneHistorique = new Historique();
            using (BDDEntities context = new BDDEntities())
            {
                uneHistorique = context.Historique.Find(id);
            }
            return uneHistorique;
        }
    }
}
