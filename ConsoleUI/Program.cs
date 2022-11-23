using Business.Concrete;
using DataAccess.Concrete.InMemory;
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

            
        }
    }
}
