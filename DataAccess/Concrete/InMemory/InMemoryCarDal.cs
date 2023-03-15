using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 4, DailyPrice = 200, ModelYear = 2006, Description = "Pugeot Partner"},
                new Car{Id = 2, BrandId = 5, ColorId = 2, DailyPrice = 500, ModelYear = 2022, Description = "Tesla Model 3"},
                new Car{Id = 3, BrandId = 5, ColorId = 4, DailyPrice = 650, ModelYear = 2023, Description = "Tesla Cybertruck"},
                new Car{Id = 4, BrandId = 3, ColorId = 7, DailyPrice = 600, ModelYear = 2019, Description = "Nissan GTR"},
                new Car{Id = 5, BrandId = 2, ColorId = 1, DailyPrice = 300, ModelYear = 2016, Description = "Volkwagen Jetta"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            //Nesnenin adresini döndürdüğü için doğruddan atama yaparsam kendisi de değişir.
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate = car;
        }
    }
}
