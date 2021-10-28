using Business.Abstract;
using Business.Constants;
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
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult DeleteBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetBrands()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result, Messages.BrandListed);
        }

        public IResult UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }
    }   
}
