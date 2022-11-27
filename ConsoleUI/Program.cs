using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    //SOLID
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (var product in productManager.GetByUnitPrice(5,30))
            {
                Console.WriteLine(product.ProductName);
            };

            

            


            
        }
    }
}
