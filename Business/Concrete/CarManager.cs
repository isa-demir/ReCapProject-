using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
        public IResult Add(Car car)
        {
            if (SaveControl(car))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductNameInvalid);
                
            }
        }

        public IResult Delete(Car car)
        {
            //Mesela -> Bunu kullanacak kişi Admin mi? gibi kontroller yapılabilir.
            if (true)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.ProductDeleted);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (_carDal.GetAll() != null)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed);
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            if (SaveControl(car))
            {
                _carDal.Update(car);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
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
