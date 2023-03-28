using DataAccess.Abstract;
using Entities.Abstract;
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
            using (RentCarContext context = new RentCarContext())
            {
                //var addedCar = context.Entry(entity);
                //addedCar.State = EntityState.Added;
                context.Cars.Add(entity); //Yukarıdaki kodlara kıyasla daha basit.
                _ = context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedCar = context.Cars.Find(entity.Id);
                context.Cars.Remove(deletedCar);
                _ = context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return filter != null ? context.Set<Car>().Where(filter).ToList()
                    : context.Set<Car>().ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                //var updatedCar = context.Entry(entity);
                //updatedCar.State = EntityState.Modified;
                context.Entry(entity).State = EntityState.Modified;
                _ = context.SaveChanges();
            }
        }
    }
}
