using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColourManager colourManager = new ColourManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            Car car1 = new Car { Id = 7, BrandId = 2, ColourId = 3, DailyPrice = 350, ModelYear = 2003, Description ="Manuel Benzinli" };

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                System.Console.WriteLine(brandManager.GetById(car.Id).BrandName);
            }
           
        }
    }
}
