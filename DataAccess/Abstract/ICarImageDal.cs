using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IRepositoryDal<CarImage>
    {
        bool IsExist(int id);
    }
}
