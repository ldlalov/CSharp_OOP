using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    internal class CarRepository : IRepository<ICar>
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
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidAddCarRepository));
            }
            cars.Add(model);
        }

        public ICar FindBy(string property)
        {
           return cars.FirstOrDefault(car => car.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
