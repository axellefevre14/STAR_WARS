using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAR_WARS_LIBRARY
{
    public class TypeDataLayer
    {

        public List<Type> getAll()
        {
            List<Type> list;
            using (BDDEntities context = new BDDEntities())
            {
                list = context.Type.ToList();
            }
            return list;
        }

        public void add(Type type)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Type.Add(type);
                context.SaveChanges();
            }
        }
        public void update(Type type)
        {
            using (BDDEntities context = new BDDEntities())
            {
                context.Type.Add(type);
                context.Entry(type).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Type getById(int id)
        {
            Type unType = new Type();
            using (BDDEntities context = new BDDEntities())
            {
                unType = context.Type.Find(id);
            }
            return unType;
        }

    }
}
