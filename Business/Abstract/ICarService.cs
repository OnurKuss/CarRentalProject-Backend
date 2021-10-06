using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<CarDetailDto> GetCarDetails();
        List<Car> GetAllCars();
        Car GetByCarId(int Id);
        void AddToCar(Car car);
        void DeleteToCar(Car car);
        void UpdateToCar(Car car);

    }
}
