using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByColorId(int Id);
        void AddToCar(Car car);
        void DeleteToCar(Car car);
        void UpdateToCar(Car car);

    }
}
