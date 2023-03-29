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

            var carDetails = carManager.GetCarDetails();

            foreach (var car in carDetails)
            {
                Console.WriteLine(car.BrandName + "/" + car.Model + " : " + car.ColorName);
            }
            
            
        }
    }
}
