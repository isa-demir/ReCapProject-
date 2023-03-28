using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dataacces erişim nesnesi
            var carDal = new EfCarDal();

            //Varlığımız üzerinde işlemleri yapmamızı sağlayan nesnemiz.
            CarManager carManager = new CarManager(carDal);

            Car car1 = new Car
            {
                Id = 1,
                Model = "A3",
                BrandId = 1,
                ColorId = 1,
                ModelYear = 2022,
                DailyPrice = 350.50m,
                Description = "Luxury compact sedan"
            };

            Car car2 = new Car
            {
                Id = 2,
                Model = "S-Class",
                BrandId = 2,
                ColorId = 2,
                ModelYear = 2021,
                DailyPrice = 950.00m,
                Description = "Luxury full-size sedan"
            };

            Car car3 = new Car
            {
                Id = 3,
                Model = "Civic",
                BrandId = 3,
                ColorId = 3,
                ModelYear = 2022,
                DailyPrice = 200.00m,
                Description = "Compact car"
            };

            List<Car> cars = new List<Car> { car1, car2, car3 };
            //carManager.Add(car3);

            //foreach (var c in cars)
            //{
            //    carManager.Add(c);
            //}

            //carManager.Delete(car3);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Description);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine("------------------");
            }
        }
    }
}
