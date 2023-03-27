using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IEntityRepository<Brand>
    {
        public void Add(Brand entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var addedBrand = context.Entry(entity);
                addedBrand.State = EntityState.Added;
                _ = context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedBrand = context.Entry(entity);
                deletedBrand.State = EntityState.Deleted;
                _ = context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return filter != null ? context.Set<Brand>().Where(filter).ToList()
                    : context.Set<Brand>().ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var updatedBrand = context.Entry(entity);
                updatedBrand.State = EntityState.Modified;
                _ = context.SaveChanges();
            }
        }
    }
}
