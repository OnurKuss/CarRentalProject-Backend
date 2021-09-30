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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RecapContext context = new RecapContext())
            {
                //var addedEntity = context.Entry(entity);
                //addedEntity.State = EntityState.Added;
                //context.SaveChanges();
                context.Cars.Add(entity);
                context.SaveChanges();

            }
        }

        public void Delete(Car entity)
        {
            using (RecapContext context= new RecapContext())
            {
                //var deletedEntity = context.Entry(entity);
                //deletedEntity.State = EntityState.Deleted;
                //context.SaveChanges();
                context.Cars.Remove(context.Cars.SingleOrDefault(p => p.Id == entity.Id));
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RecapContext context=new RecapContext())
            {
                var updatedEntity = context.Cars.SingleOrDefault(p => p.Id == entity.Id);
                updatedEntity.BrandId = entity.BrandId;
                updatedEntity.ColorId = entity.ColorId;
                updatedEntity.DailyPrice = entity.DailyPrice;
                updatedEntity.Description = entity.Description;
                updatedEntity.ModelYear = entity.ModelYear;
                context.SaveChanges();
            }
        }
    }
}
