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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);

                return new SuccessResult(Messages.colorAdded);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }
        }

        public IResult Delete(Color color)
        {
            ; _colorDal.Delete(color);
            return new SuccessResult(Messages.colorDeleted);
        }

        public IResult GetById(int colorId)
        {
            _colorDal.Get(c=> c.ColorId == colorId );

            return new SuccessResult(Messages.colorGet);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.colorListed);
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.colorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.errorAll);
            }
        }
    }
}
