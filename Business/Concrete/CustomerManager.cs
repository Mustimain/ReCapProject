using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length > 2)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.customerAdded);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult(Messages.customerDeleted);
        }

        public IResult GetById(int customerId)
        {
            _customerDal.Get(c=> c.CustomerId == customerId);

            return new SuccessResult(Messages.customerGet);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.customerListed);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length > 2)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.customerUpdated);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }

        }
    }
}
