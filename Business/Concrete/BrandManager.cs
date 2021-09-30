using Business.Abstract;
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
        public void AddBrand(Brand brand)
        {
            int name = brand.BrandName.Length;
            if (name>=2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("En az iki karakterli olmalı");
            }
            
        }

        public void DeleteBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetBrands()
        {
            return _brandDal.GetAll();
        }

        public void UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
