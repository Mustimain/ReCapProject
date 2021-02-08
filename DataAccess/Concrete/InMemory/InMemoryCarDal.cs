using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        ICarDal _carDal;

        public InMemoryCarDal(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
          
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }


        List<Car> _cars;

        public InMemoryCarDal()
        {
            

            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColourId = 1 , ModelYear = 2018 , DailyPrice = 500, Description = "Orta Kalite Araba"},
                new Car {Id = 2, BrandId = 2, ColourId = 2 , ModelYear = 2015 , DailyPrice = 325, Description = "Güzel Araba"},
                new Car {Id = 3, BrandId = 3, ColourId = 3 , ModelYear = 2019 , DailyPrice = 600, Description = "Aile Arabası"},
                new Car {Id = 4, BrandId = 4, ColourId = 2 , ModelYear = 2020 , DailyPrice = 690, Description = "Lüks Marka Araba"},
                new Car {Id = 5, BrandId = 5, ColourId = 1 , ModelYear = 2009 , DailyPrice = 150, Description = "Düşük Bütçeli Aile Arabası"}

            };

        }

       

        public List<Car> GetAll()
        {
            
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.Where(cr=> cr.Id == car.Id).FirstOrDefault();
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
