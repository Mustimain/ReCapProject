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
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public IResult Add(Colour colour)
        {
            if (colour.ColourName.Length > 2)
            {
                _colourDal.Add(colour);

                return new SuccessResult(Messages.colorAdded);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }
        }

        public IResult Delete(Colour colour)
        {
            ; _colourDal.Delete(colour);
            return new SuccessResult(Messages.colorDeleted);
        }

        public IResult Get(Colour colour)
        {
            _colourDal.Get(c=> c.ColourId == colour.ColourId );

            return new SuccessResult(Messages.colorGet);
        }

        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(),Messages.colorListed);
        }

        public IResult Update(Colour colour)
        {
            if (colour.ColourName.Length > 2)
            {
                _colourDal.Update(colour);
                return new SuccessResult(Messages.colorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }
        }
    }
}
