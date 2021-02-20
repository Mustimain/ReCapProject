using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.ColorId
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 Id = cr.Id,
                                 CarName = br.BrandName,
                                 BrandId = br.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = cl.ColorId,
                                 ColorName = cl.ColorName,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description

                                 

                             };

                return result.ToList();

            }
        }


    }
}
