using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IResult Add(Colour colour);
        IResult Update(Colour colour);
        IResult Delete(Colour colour);
        IResult Get(Colour colour);

    }
}
