using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {

        public string model;
        public Engine engine;
        public Cargo cargo;
        public List<Tires> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tires> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

    }
}
