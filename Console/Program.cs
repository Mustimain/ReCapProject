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

            Car car1 = new Car { Id = 10, BrandId = 2, ColourId = 1, DailyPrice = 255, Description = "Hybrid Otomatik", ModelYear = 2016 };

            // carManager.Add(car1);

            Car car2 = new Car { Id = 2, BrandId = 3, ColourId = 5, DailyPrice = 1000, Description = "Güncellendi", ModelYear = 2001 };

            // carManager.Update(car2);


            // carManager.Delete(carManager.Get(2));

            // AllCarListele(carManager);
            

        }

        private static void AllCarListele(CarManager carManager)
        {
            System.Console.WriteLine("ARAÇ LİSTESİ\n");


            foreach (var car in carManager.GetCarDetail())
            {
                System.Console.WriteLine("Car Name: {0}      Brand Name: {1}     Colour Name: {2}     Daily Price: {3}", car.CarName, car.BrandName, car.ColourId, car.DailyPrice);
            }
        }
    }
}
