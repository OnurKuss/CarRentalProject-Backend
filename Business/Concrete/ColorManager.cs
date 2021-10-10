using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteColor(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetColors()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateColor(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
