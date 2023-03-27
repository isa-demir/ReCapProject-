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
            if (SaveControl(car))
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Model adı 2 karakterden fazla olmalı veya günlük fiyat 0'dan büyük olmalıdır.");
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
            return _carDal.Get(p=>p.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            if (SaveControl(car))
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Model adı 2 karakterden fazla olmalı veya günlük fiyat 0'dan büyük olmalıdır.");
            }
        }

        private bool SaveControl(Car car)
        {
            if (car.Model.Length >= 2 && car.DailyPrice > 0)
            {
                return true;
            }
            return false;
        }
    }
}
