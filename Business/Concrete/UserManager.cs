using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           
             _userDal.Add(user);
             return new SuccessResult(Messages.userAdded);
            
        }

        public IResult Delete(User userr)
        {
            _userDal.Delete(userr);

            return new SuccessResult(Messages.userDeleted);
        }

        public IResult GetById(int userId)
        {
            _userDal.Get(u => u.UserId == userId);

            return new SuccessResult(Messages.userGet);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.userListed);
        }


        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {

            
             _userDal.Update(user);
             return new SuccessResult(Messages.userUpdated);
            

        }
    }
}
