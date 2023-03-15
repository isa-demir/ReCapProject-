using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //Dependency Injection yöntemini uyguladım.
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.Id > 1 && car.BrandId > 1 && car.ColorId > 1)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen girilen ID değerlerini kontrol ediniz.");
            }
        }

        public void Delete(Car car)
        {
            //Mesela -> Bunu kullanacak kişi Admin mi? gibi kontroller yapılabilir.
            if (true)
            {
                _carDal.Delete(car);
            }
        }

        public List<Car> GetAll()
        {
            if (_carDal.GetAll() != null)
            {
                return _carDal.GetAll();
            }
            throw new Exception();
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }

        public void Update(Car car)
        {
            if (car.Id > 1 && car.BrandId > 1 && car.ColorId > 1)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Lütfen girilen ID değerlerini kontrol ediniz.");
            }
        }
    }
}
