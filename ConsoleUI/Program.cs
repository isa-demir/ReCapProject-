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

            //Tüm Arabalar Listeleniyor
            GetCarDetails(carManager);

            Car car = new Car
            {
                Id = 4,
                BrandId = 5,
                Model = "Rifter",
                ColorId = 5,
                ModelYear = 2022,
                DailyPrice = 250,
                Description = "Geniş iç hacmi, yüksek konforu ve modern tasarımıyla dikkat çekiyor."
            };

            //Araba ekleme yapılıyor!
            //carManager.Add(car);

            //Tüm Arabalar Listeleniyor
            GetCarDetails(carManager);

            //Araba silme yapılıyor!
            //var deletedCar = carManager.GetById(2);
            //carManager.Delete(deletedCar.Data);

            //Tüm Arabalar Listeleniyor
            GetCarDetails(carManager);

            //Araba güncelleme yapılıyor!
            car.DailyPrice = 300;
            carManager.Update(car);

            //Tüm Arabalar Listeleniyor
            GetCarDetails(carManager);

            //Sadece tek bir araba getiriliyor!
            var wantedCar = carManager.GetById(4);
            Console.WriteLine(wantedCar.Data.Model + "/" + wantedCar.Data.Description);

            //CarDetailDto işleminin yapıldığı metod.
            //GetCarDetails(carManager);

        }

        private static void GetCarDetails(CarManager carManager)
        {
            Console.WriteLine("\n---------------------------------------\n");
            var carDetails = carManager.GetCarDetails();

            foreach (var car in carDetails.Data)
            {
                Console.WriteLine(car.BrandName + "/" + car.Model + " : " + car.ColorName + " -> " + car.DailyPrice);
            }
        }
    }
}
