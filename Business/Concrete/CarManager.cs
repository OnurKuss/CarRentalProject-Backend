using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddToCar(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DeleteToCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result,Messages.CarListed);
        }

        public IDataResult<Car> GetByCarId(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarId==Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();

            return new SuccessDataResult<List<CarDetailDto>>(result,Messages.CarDetail);
        }

        public IResult UpdateToCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
