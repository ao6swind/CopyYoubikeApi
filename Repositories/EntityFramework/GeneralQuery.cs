using DbContexts;
using Microsoft.EntityFrameworkCore;
using Pluralize.NET.Core;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
namespace Repositories.EntityFramework
{
    public class GeneralQuery<T> : IGeneralQuery<T> where T : class
    {
        public bool Create(T entity)
        {
            using (DbEasyLife db = new DbEasyLife())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
                return true;
            }
        }

        public T Find(int id)
        {
            using (DbEasyLife db = new DbEasyLife())
            {
                return db.Set<T>().Find(id);
            }
        }

        public bool Update(int id, T entity)
        {
            using (DbEasyLife db = new DbEasyLife())
            {
                db.Set<T>().Update(entity);
                db.SaveChanges();
                return true;
            }
        }
    }
}
