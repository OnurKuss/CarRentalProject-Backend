using Business.Concrete;
using Core.Entities.Concrete;
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental()
            {
                RentalId=2,
                CarId=2,
                CustomerId=2,
                RentDate = new DateTime(2021, 10, 12),
                ReturnDate = new DateTime(2021, 10, 15)
            };

            var result= rentalManager.IsCarEverRented(5);
            Console.WriteLine(result.Message);

            //rentalManager.UpdateRental(rental);
            //var result = rentalManager.AddRental(rental);
            //Console.WriteLine(result.Message);

            //GetAllRental();








            //GetAllCustomer();
            //AddDeleteUpdateCustomer();


            //GetAllUsers();
            //AddDeleteUpdateUsers();

            //CarDetails();
            //GetAllCar();
            //AddDeleteUpdateCar();

        }

        private static void GetAllRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result1 = rentalManager.GetAllRentals();


            if (result1.Success)
            {
                Console.WriteLine(result1.Message);
                foreach (var rentalCar in result1.Data)
                {
                    Console.WriteLine(rentalCar.RentalId + " / " + rentalCar.CustomerId + " / " + rentalCar.CarId + " /" + rentalCar.RentDate + " / " + rentalCar.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result1.Message);
            }
        }

        private static void GetAllCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAllCustomers();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Müşteri Id : " + customer.CustomerId + "\n Şirket Adı : " + customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddDeleteUpdateCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = new Customer() { UserId = 1004, CompanyName = "HakanCompany" };
            var result = customerManager.AddCustomer(customer);
            Console.WriteLine(result.Message);
            //var result2 = customerManager.AddCustomer(customer);
            //Console.WriteLine(result2.Message);
            //var result3 = customerManager.AddCustomer(customer);
            //Console.WriteLine(result3.Message);
        }

        private static void GetAllUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAllUsers();

            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var user in result.Data)
                {
                    Console.WriteLine("{0}: \n {1}  \n {2}  \n {3}  ", user.UserId, user.FirstName, user.LastName, user.Email);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddDeleteUpdateUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User()
            {
                FirstName = "Hakan",
                LastName = "Bursa",
                Email = "hakangmail"
            };
            userManager.AddUser(user);
            //userManager.DeleteUser(user);
            //userManager.UpdateUser(user);
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine(carDetail.BrandName + " / " + carDetail.ColorName + " / " + carDetail.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAllCars();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " -- " + car.DailyPrice + " -- " + car.ModelYear + " -- " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddDeleteUpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car()
            {
                CarId = 14,
                BrandId = 3,
                ColorId = 1,
                DailyPrice = 600,
                ModelYear = 2018,
                Description = "Gasoline"
            };

            var deleteCar = carManager.DeleteToCar(car1);
            Console.WriteLine(deleteCar.Message);

            //var addCar = carManager.AddToCar(car1);
            //Console.WriteLine(addCar.Message);

            //var updateCar = carManager.UpdateToCar(car1);
            //Console.WriteLine(updateCar.Message);
        }
    }
}
