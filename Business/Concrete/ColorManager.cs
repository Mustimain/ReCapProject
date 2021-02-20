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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            
            _colorDal.Add(color);

            return new SuccessResult(Messages.colorAdded);
            
        
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


        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            
            _colorDal.Update(color);
            return new SuccessResult(Messages.colorUpdated);
           
        }
    }
}
