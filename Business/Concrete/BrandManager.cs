using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddBrand(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));
            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);

            return new SuccessResult("Başarıyla eklendi");

        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetBrands()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result, Messages.BrandListed);
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private IResult CheckIfBrandNameExists(string brandName)
        {
            var rentable = _brandDal.GetAll(b => b.BrandName == brandName).Any();

            if (rentable)
            {
                return new ErrorResult("Aynı isim girilemez");
            }

            return new SuccessResult();
        }
    }
}
