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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null && _rentalDal.GetRentalDetails(c=> c.CarId == rental.CarId).Count > 0)
            {
                return new ErrorResult(Messages.rentalAdded);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.errorAll);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.rentalDeleted);
        }

        public IResult GetById(int rentalId)
        {
            _rentalDal.Get(r=> r.CarId == rentalId);

            return new SuccessResult(Messages.rentalGet);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.rentalListed);
        }

        public IResult Update(Rental rental)
        {

            if (rental.ReturnDate == null && _rentalDal.GetRentalDetails(c => c.CarId == rental.CarId).Count > 0)
            {
                return new ErrorResult(Messages.errorAll);
            }
            else
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.rentalUpdated);
            }
        }
    }
}
