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
using System.Linq;
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
            var imageCount = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (imageCount != null)
            {
                return imageCount;
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
            var image = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (image == null)
            {
                return new ErrorResult("Araba resmi bulunamadı");
            }
            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Araba resmi başarıyla silindi");
        }

        public IResult UpdateCarImage(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (image == null)
            {
                return new ErrorResult("Araba resmi bulunamadı");
            }
            FileHelper.Update(file, image.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult("Araba resmi güncellendi");
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result, "Araba resmi listesi");
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetCarImageByCarId(int carId)
        {
            var result = _carImageDal.Get(c=> c.CarId==carId);
            var path = "logo.jpg";
            if (result.ImagePath!=null)
            {
                return new SuccessDataResult<CarImage>(result);
            }
            result.ImagePath = path;
            return new ErrorDataResult<CarImage>(result);

        }


        //Business Code

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult("Bir arabanın en fazla 5 resmi olabilir.");
            }
            return new SuccessResult();
        }

        
    }
}
