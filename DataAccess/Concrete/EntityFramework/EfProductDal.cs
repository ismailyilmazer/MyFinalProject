using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : Abstract.EfProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var addedEntity=contex.Entry(entity);
                addedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                return contex.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                return filter == null ? contex.Set<Product>().ToList() : contex.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
