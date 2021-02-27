using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage,ReCapProjectContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.CarImages.Any(p => p.Id == id);
            }
        }
    }
}
