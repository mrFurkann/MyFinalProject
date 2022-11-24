using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new InMemoryCustomerDal());
            
            foreach (var customer in customerManager.GetAll())
            {
                Console.WriteLine(customer.FirstName);
            }

            Customer customer1 = new Customer
            {
                CustomerId = 5, FirstName="Elif",LastName="Demir",City="Sinop"
            };

            customerManager.Add(customer1);

            Console.WriteLine("-------------New Customer-------------");


            Customer customer2 = new Customer
            {
                CustomerId = 6, FirstName = "Tuana", LastName = "Derin", City = "Trabzon"
            };
            customerManager.Add(customer2);

            Customer customer3 = new Customer
            {
                CustomerId = 7,
                FirstName = "Rabia",
                LastName = "Kara",
                City = "Kastamonu"
            };
            customerManager.Add(customer3);

            Customer customer4 = new Customer
            {
                CustomerId = 8,
                FirstName = "Salih",
                LastName = "Yıldız",
                City = "Rize"
            };
            customerManager.Add(customer4);

            Customer customer5 = new Customer
            {
                CustomerId = 9,
                FirstName = "Yıldıray",
                LastName = "Mas",
                City = "Mardin",
                CompanyId = 2

            };
            customerManager.Add(customer5);

            foreach (var customer in customerManager.GetAll())
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.WriteLine("-------------Deleted Customer List-------------");

             customerManager.Delete(customer4);

            foreach (var customer in customerManager.GetAll())
                {
                    Console.WriteLine(customer.FirstName);
                }


            Console.WriteLine("-------------Update Customer List-------------");

           


            customerManager.Update(customer5);

            foreach (var customer in customerManager.GetAll())
            {
                Console.WriteLine(customer.FirstName);
            }

        }
    }
}
