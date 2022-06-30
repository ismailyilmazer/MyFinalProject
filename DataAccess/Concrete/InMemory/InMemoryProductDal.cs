using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : Abstract.EfProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
                _products = new List<Product>() { 
                new Product{ CategoryId=123, ProductId =15, ProductName="televizyon", UnitPrice=1900, UnitsInStock=2},
                new Product{ CategoryId=124, ProductId =14, ProductName="araba", UnitPrice=280000, UnitsInStock=2},
                new Product{ CategoryId=125, ProductId =13, ProductName="buzdolabı", UnitPrice=5500, UnitsInStock=2},
                new Product{ CategoryId=126, ProductId =12, ProductName="telefon", UnitPrice=4000, UnitsInStock=2},
                new Product{ CategoryId=127, ProductId =11, ProductName="bilgisayar", UnitPrice=15000, UnitsInStock=2}

             };

        }

        public void Add(Product entity)
        {
            _products.Add(entity);
        }

        public void Delete(Product entity)
        {
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p => p.CategoryId == entity.CategoryId); 
            _products.Remove(productToDelete);
        }

      
        public List<Product> GetAll()
        {
            return _products;
        }

       
        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName= product.ProductName;   
            productToUpdate.UnitPrice= product.UnitPrice;   
            productToUpdate.UnitsInStock= product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();   
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return  _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return new Product();
        }
    }
}
