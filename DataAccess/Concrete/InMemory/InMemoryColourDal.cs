using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        public void Add(Color color)
        {
            _colors.Add(color);
            Console.WriteLine("{0} Eklendi",color.ColorName);
        }

        public void Delete(Color color)
        {
            Color _deleteToColor = _colors.SingleOrDefault(cl => cl.ColorId == color.ColorId);
            _colors.Remove(_deleteToColor);
        }

        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {

                new Color{ColorId = 1,ColorName = "White"},
                new Color{ColorId = 2,ColorName = "Black"},
                new Color{ColorId = 3,ColorName = "Red"},
                new Color{ColorId = 4,ColorName = "Yellow"},
                new Color{ColorId = 5,ColorName = "Green"},


            };  

        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public void Update(Color colour)
        {
            Color updateToColor = _colors.SingleOrDefault(cl => cl.ColorId == colour.ColorId);
            updateToColor.ColorId = colour.ColorId;
            updateToColor.ColorName = colour.ColorName;

            Console.WriteLine("Güncellendi");
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
