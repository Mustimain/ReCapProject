using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColourDal : IColourDal
    {
        public void Add(Colour colour)
        {
            _colours.Add(colour);
            Console.WriteLine("{0} Eklendi",colour.ColourName);
        }

        public void Delete(Colour colour)
        {
            Colour _deleteToColour = _colours.SingleOrDefault(cl => cl.ColourId == colour.ColourId);
            _colours.Remove(_deleteToColour);
        }

        List<Colour> _colours;

        public InMemoryColourDal()
        {
            _colours = new List<Colour>
            {

                new Colour{ColourId = 1,ColourName = "White"},
                new Colour{ColourId = 2,ColourName = "Black"},
                new Colour{ColourId = 3,ColourName = "Red"},
                new Colour{ColourId = 4,ColourName = "Yellow"},
                new Colour{ColourId = 5,ColourName = "Green"},


            };  

        }

        public List<Colour> GetAll()
        {
            return _colours;
        }

        public void Update(Colour colour)
        {
            Colour updateToColour = _colours.SingleOrDefault(cl => cl.ColourId == colour.ColourId);
            updateToColour.ColourId = colour.ColourId;
            updateToColour.ColourName = colour.ColourName;

            Console.WriteLine("Güncellendi");
        }

        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Colour Get(Expression<Func<Colour, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
