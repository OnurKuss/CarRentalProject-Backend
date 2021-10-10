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
                CarId = 17,
                BrandId = 3,
                ColorId = 1,
                DailyPrice = 600,
                ModelYear = 2018,
                Description = "Gasoline"
            };
            //var result = carManager.AddToCar(car1);
            //Console.WriteLine(result.Message);
            

            Add_Delete_Update(carManager, car1);
            //CarDetails(carManager);



        }

        private static void Add_Delete_Update(CarManager carManager, Car car1)
        {
            var result = carManager.DeleteToCar(car1);
            Console.WriteLine(result.Message); 
            
        }

        private static void CarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine(carDetail.BrandName + " /" + carDetail.ColorName + " /" + carDetail.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
