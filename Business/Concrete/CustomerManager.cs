using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

       
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }



        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            var customer2=_customerDal.GetById(customer.CustomerId);
            if(customer2 != null)
                _customerDal.Delete(customer2);
        }

       

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }


        public List<Customer> GetAll()
        {
            //İş Kodları

            return _customerDal.GetAll();


        }
    }
}
