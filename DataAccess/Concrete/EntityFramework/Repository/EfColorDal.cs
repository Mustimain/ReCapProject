using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfColorDal : IColourDal
    {
        public void Add(Colour entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Colour entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Colour Get(Expression<Func<Colour, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Colour>().SingleOrDefault(filter);
            }
        }

        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return filter == null 
                    ? context.Set<Colour>().ToList() 
                    : context.Set<Colour>().Where(filter).ToList();

            }
        }

  

        public void Update(Colour entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
