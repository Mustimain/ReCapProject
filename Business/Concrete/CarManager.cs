using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        [SecuredOperation("admin,car.add")]
        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            
             _carDal.Add(car);

             return new SuccessResult(Messages.carAdded);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.carDelete);
        }

        [PerformanceAspect(10)]
        public IResult GetById(int carId)
        {
            _carDal.Get(c => c.Id == carId);

            return new SuccessResult(Messages.carFilter);
        }

        [PerformanceAspect(10)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.carListAll);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.carDetailDto);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),Messages.carBrand);
        }

        public IDataResult<List<Car>> GetCarsByColourId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),Messages.carColour);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {

            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);

            return new SuccessResult(Messages.carUpdate);
            
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
