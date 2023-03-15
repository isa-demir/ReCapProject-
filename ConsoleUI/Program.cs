using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dataacces erişim nesnesi
            ICarDal carDal = new InMemoryCarDal();

            //Varlığımız üzerinde işlemleri yapmamızı sağlayan nesnemiz.
            CarManager carManager = new CarManager(carDal);

            carManager.Add(new Car { BrandId = 9, ColorId = 2, Id = 6, DailyPrice = 1000, ModelYear = 2023, Description = "Bugatti Chiron" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description} - {car.ColorId}");
            }

            //ID'si 1 olan aracın açıklamasını yazdırır.
            Console.WriteLine(carManager.GetById(1).Description);

            Console.WriteLine("\n-----------------------------------------\n");
            var car1 = new Car { BrandId = 9, ColorId = 3, Id = 6, DailyPrice = 1000, ModelYear = 2023, Description = "Bugatti Chiron" };
            
            carManager.Update(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description} - {car.ColorId}");
            }
        }
    }
}
