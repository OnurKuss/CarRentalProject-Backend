using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car()
            {
                CarId = 8,
                BrandId = 7,
                ColorId = 3,
                DailyPrice = 1999,
                ModelYear = 2007,
                Description = "Benzin"
            };
            //carManager.AddToCar(car1);
            //carManager.DeleteToCar(car1);
            //car1.DailyPrice = 699;
            //carManager.UpdateToCar(car1);

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.BrandName + " /" + carDetail.ColorName + " /" + carDetail.DailyPrice);
            }

            //GetAllCars kullanımı

            //foreach (var car in carManager.GetAllCars())
            //{
            //    Console.WriteLine("{0}---{1}---{2}", car.CarId, car.Description, car.DailyPrice);
            //}

            //GetByCarId kullanımı

            //Console.WriteLine(carManager.GetByCarId(1).Description);
            //Console.WriteLine(carManager.GetByCarId(2).Description);
            //Console.WriteLine(carManager.GetByCarId(3).Description);











        }
    }
}
