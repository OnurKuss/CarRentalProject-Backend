using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult AddCarImage(IFormFile file, CarImage carImage)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("Bir arabanın en fazla 5 resmi olabilir.");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult("Araba resmi eklendi");
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            var result= _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result, "Araba resim listesi");
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetByCarImageId(int CarImageId)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateCarImage(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }


        //Business Code

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
