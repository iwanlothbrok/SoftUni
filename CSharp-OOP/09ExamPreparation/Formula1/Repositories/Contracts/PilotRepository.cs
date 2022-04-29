﻿using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;
        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot model)
        {
          pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
           
           return pilots.FirstOrDefault(n=>n.FullName == name); 
        }

        public bool Remove(IPilot model)
        {
          return pilots.Remove(model);  
        }
    }
}