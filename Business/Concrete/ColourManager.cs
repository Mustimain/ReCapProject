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

        public Colour Get(int colourId)
        {
            return _colourDal.Get(cl=> cl.ColourId == colourId);
        }

        public List<Colour> GetAll()
        {
            return _colourDal.GetAll();

        }

        public void Update(Colour colour)
        {
            _colourDal.Update(colour);
        }
    }
}
