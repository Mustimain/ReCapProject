using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand _deleteToBrand = _brands.SingleOrDefault(br => br.BrandId == brand.BrandId);
            _brands.Remove(_deleteToBrand);
        }

        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {

                new Brand { BrandId = 1, BrandName = "BMW"},
                new Brand { BrandId = 2, BrandName = "Audi"},
                new Brand { BrandId = 3, BrandName = "Mercedes"},
                new Brand { BrandId = 4, BrandName = "Honda"},
                new Brand { BrandId = 5, BrandName = "Wolsvagen"},


            };

           
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public void Update(Brand brand)
        {
            Brand updateToBrand = _brands.SingleOrDefault(br => br.BrandId == brand.BrandId);
            updateToBrand.BrandId = brand.BrandId;
            updateToBrand.BrandName = brand.BrandName;

        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
