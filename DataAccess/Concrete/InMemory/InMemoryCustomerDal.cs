using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
   
 
    public class InMemoryCustomerDal : ICustomerDal
    {

        List<Customer> _customers;
        
        public InMemoryCustomerDal()
        {
            //Bir VeriTabanından Geliyormuş Gibi Davranıyoruz.
            _customers = new List<Customer>
            {
                new Customer{CustomerId=1,FirstName="Furkan",LastName="Koşar",City="İstanbul",CompanyId=1},
                new Customer{CustomerId=2,FirstName="Talha",LastName="Yıldız",City="Rize",CompanyId=2},
                new Customer{CustomerId=3,FirstName="Resul",LastName="Koca",City="Samsun",CompanyId=1},
                new Customer{CustomerId=4,FirstName="Engin",LastName="Demiroğ",City="Ankara",CompanyId=2},

            };
        }




        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            //foreach (var x in _customers)
            //{
            //    if (customer.CustomerId == x.CustomerId)
            //    {
            //        customerToDelete = x;
            //    }
            //}


            //Lamda =>
            //LİNQ - Language Integrated Query SQl Gibi filtreleyebiliyoruz
           
            Customer customerToDelete =_customers.SingleOrDefault(x => x.CustomerId == customer.CustomerId);

            _customers.Remove(customerToDelete);
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

       

        public void Update(Customer customer)
        {
            //Gönderdiğim müşteri id'sine sahip olan listedeki müşteriyi bul
            Customer customerToUptade = _customers.SingleOrDefault(x => x.CustomerId == customer.CustomerId);

            customerToUptade.FirstName = customer.FirstName;
            customerToUptade.LastName = customer.LastName;
            customerToUptade.City = customer.City;

            


        }
        public Customer GetById(int customerId)
        {
            return _customers.FirstOrDefault(x => x.CustomerId == customerId);
        }
    }
}
