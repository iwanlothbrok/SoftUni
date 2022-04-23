using Formula1.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories.Contracts
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>  
    {
        private List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => cars;
        
        public void Add(IFormulaOneCar model)
        {
          cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
          return cars.FirstOrDefault(n=>n.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
         return cars.Remove(model);
        }
    }
}
