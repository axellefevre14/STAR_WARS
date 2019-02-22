using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    public class CombatDataLayer
    {
        public List<Combat> getAll()
        {
            List<Combat> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Combat.Include("Wookie, Droide, Bataille").ToList();
            }
            return list;
        }

        public void add(Combat combat)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Combat.Add(combat);
                context.SaveChanges();
            }
        }
        public void update(Combat combat)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Combat.Add(combat);
                context.Entry(combat).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Combat getById(int id)
        {
            Combat unCombat = new Combat();
            using (BDDEntities context = new BDDEntities())
            {
                unCombat = context.Combat.Find(id);
            }
            return unCombat;
        }
    }
}
