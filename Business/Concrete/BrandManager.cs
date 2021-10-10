using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult AddBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }
    }   
}
