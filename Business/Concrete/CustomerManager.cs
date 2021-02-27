using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.customerAdded);
            
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


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.customerUpdated);
            
        }
    }
}
