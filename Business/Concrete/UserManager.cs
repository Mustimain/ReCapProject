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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length > 2 && user.LastName.Length > 2 && user.Email.Length > 10 && user.Password.Length < 16 && user.Password.Length > 8)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.userAdded);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }
        }

        public IResult Delete(User userr)
        {
            _userDal.Delete(userr);

            return new SuccessResult(Messages.userDeleted);
        }

        public IResult Get(User user)
        {
            _userDal.Get(u => u.UserId == user.UserId);

            return new SuccessResult(Messages.userGet);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.userListed);
        }

        public IResult Update(User user)
        {

            if (user.FirstName.Length > 2 && user.LastName.Length > 2 && user.Email.Length > 10 && user.Password.Length < 16 && user.Password.Length > 8)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.userUpdated);
            }
            else
            {
                return new ErrorResult(Messages.userDeleted);
            }

        }
    }
}
