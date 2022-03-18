

using System;
using System.Collections.Generic;
using System.Linq;

namespace p04PizzaCalories
{
    public class Pizza
    {
        private string name;
        public List<Topping> toppings;
        public Pizza(string name,Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 1 || value.Length > 15 || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get;private set; }

        public double Calories => Dough.Calories + toppings.Sum(c => c.Calories);


        public void AddToppings(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        
    }
}
