using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public void Add(Colour colour)
        {
            _colourDal.Add(colour);
        }

        public void Delete(Colour colour)
        {
            _colourDal.Delete(colour);
        }

        public List<Colour> GetAll()
        {
            return _colourDal.GetAll();

        }

        public Colour GetById(int Id)
        {
            return _colourDal.Get(c => c.ColourId == Id);
        }

        public void Update(Colour colour)
        {
            _colourDal.Update(colour);
        }
    }
}
