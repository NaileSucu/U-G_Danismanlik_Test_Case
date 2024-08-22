using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Customer GetByID(int id)
        {
            return _customerDal.GetByID(id);
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetList();
        }

        public void Update(Customer t)
        {
            _customerDal.Update(t);
        }
    }
}
