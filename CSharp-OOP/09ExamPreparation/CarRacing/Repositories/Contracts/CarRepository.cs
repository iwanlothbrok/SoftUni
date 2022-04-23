using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories.Contracts
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;
        public CarRepository()
        {
             cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => cars;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
           cars.Add(model);
        }

        public ICar FindBy(string property)
        {
           return cars.FirstOrDefault(num=>num.VIN == property);
        }

        public bool Remove(ICar model)
        {
           return cars.Remove(model);
        }
    }
}
