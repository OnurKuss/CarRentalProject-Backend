using Business.Abstract;
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

        public void AddToCar(Car car)
        {
            _carDal.Add(car);
        }

        public void DeleteToCar(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }

        public Car GetByCarId(int Id)
        {
            return _carDal.Get(c=> c.CarId==Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void UpdateToCar(Car car)
        {
            _carDal.Update(car);
        }
    }
}
