using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(p => p.BrandId == Id);
        }
        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(p=> p.ColorId == Id);
        }
        public void AddToCar(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen günlük kiralama bedelini 0'dan büyük olarak belirleyiniz.");
            }
        }

        public void DeleteToCar(Car car)
        {
            _carDal.Delete(car);
        }
        public void UpdateToCar(Car car)
        {
            _carDal.Update(car);
        }
    }
}
