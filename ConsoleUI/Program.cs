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

            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.BrandId + " : " + car.ModelYear);
            //}
            //foreach (var car in carManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(car.Description + " : " + car.ColorId);
            //}
            //carManager.AddToCar(new Car { Id = 6, BrandId = 3, ColorId = 4, DailyPrice = 1100, ModelYear = 2017, Description = "Benzinli" });
            carManager.UpdateToCar(new Car { Id = 6, BrandId = 3, ColorId = 4, DailyPrice = 1100, ModelYear = 2005, Description = "Benzinli" });
            //carManager.DeleteToCar(new Car {Id=7 });
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.AddBrand(new Brand { BrandId = 7, BrandName = "Bentley" });
            //foreach (var brand in brandManager.GetBrands())
            //{
            //    Console.WriteLine("{0}--{1}" , brand.BrandId , brand.BrandName);
            //}







        }
    }
}
