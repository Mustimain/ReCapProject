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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            
            _brandDal.Add(brand);

            return new SuccessResult(Messages.brandAdded);
            
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.brandDeleted);
        }

        public IResult GetById(int brandId)
        {
            _brandDal.Get(b => b.BrandId == brandId);

            return new SuccessResult(Messages.brandGet);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.brandListed);
        }



        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            
            _brandDal.Update(brand);
            return new SuccessResult(Messages.brandUpdated);
           
        }
    }
}
