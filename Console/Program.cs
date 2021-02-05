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

            Car car1 = new Car { Id = 6, BrandId = 2, ColourId = 2, DailyPrice = 300, Description = "Emre", ModelYear = 2020 };

            carManager.Update(car1);

            System.Console.WriteLine("Mustafa Ceylan");


        }
    }
}
