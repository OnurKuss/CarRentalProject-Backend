using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecapContext context=new RecapContext())
            {
                var addedColor = context.Entry(entity);
                addedColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecapContext context=new RecapContext())
            {
                var deletedColor = context.Entry(entity);
                deletedColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapContext context=new RecapContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().ToList();
            }
        }

        public void Update(Color entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var updatedColor = context.Entry(entity);
                updatedColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
