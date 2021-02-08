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
                             join cl in context.Colours
                             on cr.ColourId equals cl.ColourId
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 Id = cr.Id,
                                 BrandId = br.BrandId,
                                 ColourId = cl.ColourId,
                                 BrandName = br.BrandName,
                                 ColourName = cl.ColourName,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ModelYear = cr.ModelYear,
                                 CarName = br.BrandName
                                 

                             };

                return result.ToList();

            }
        }


    }
}
