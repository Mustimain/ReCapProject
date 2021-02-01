using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
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
                new Car {Id = 1, BrandId = 1, ColourId = 1 , ModelYear = 2018 , DailyPrice = 500, Description = "Mercedes A180"},
                new Car {Id = 2, BrandId = 2, ColourId = 2 , ModelYear = 2015 , DailyPrice = 325, Description = "Mercedes E220d"},
                new Car {Id = 3, BrandId = 2, ColourId = 3 , ModelYear = 2019 , DailyPrice = 600, Description = "BMW 320d"},
                new Car {Id = 4, BrandId = 5, ColourId = 2 , ModelYear = 2020 , DailyPrice = 690, Description = "Audi Q5"},
                new Car {Id = 5, BrandId = 7, ColourId = 1 , ModelYear = 2009 , DailyPrice = 150, Description = "Toyota Corolla"},
                new Car {Id = 6, BrandId = 11, ColourId = 3 , ModelYear = 2011 , DailyPrice = 250, Description = "Hyundai Accent"},

            };
        }

        public List<Car> GetAll()
        {
            
            return _cars;
        }

        public List<Car> GetById(int byId)
        {
            return _cars.Where(c => c.Id == byId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
