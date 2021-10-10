using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetAllCars();
        IDataResult<Car> GetByCarId(int Id);
        IResult AddToCar(Car car);
        IResult DeleteToCar(Car car);
        IResult UpdateToCar(Car car);

    }
}
