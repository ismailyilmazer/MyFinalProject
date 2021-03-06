using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager (new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {

                Console.WriteLine(product.ProductName);
            }
        }
    }
}
