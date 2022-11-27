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
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDısposable pattern imlementation of c#
            using (NorthwindContext contex = new NorthwindContext())
            {

                var addedEntity = contex.Entry(entity);  //referansı yakala
                addedEntity.State = EntityState.Added;   //Bu eklenecek Nesne
                contex.SaveChanges();  //Ve Ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {

                var deletedEntity = contex.Entry(entity);  
                deletedEntity.State = EntityState.Deleted;   
                contex.SaveChanges();  
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); 
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {

                return filter==null ? contex.Set<Product>().ToList():contex.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {

                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
