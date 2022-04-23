
using Formula1.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        public IReadOnlyCollection<IRace> Models => races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.FirstOrDefault(n => n.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
        
    }
}
