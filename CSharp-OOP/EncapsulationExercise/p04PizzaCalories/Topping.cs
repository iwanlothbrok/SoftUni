

using System;
using System.Collections.Generic;

namespace p04PizzaCalories
{
    public class Topping
    {
        private int weight;
        private string toppingType;

        private readonly Dictionary<string, double> validators = new Dictionary<string, double>()
        {
            {"meat",1.2 },
            {"veggies",0.8 },
            {"cheese",1.1 },
            {"sauce",0.9}
        };

        public Topping(string topping, int weight)
        {
            ToppingType = topping;
            Weight = weight;
        }
        public string ToppingType
        {
            get => toppingType;

           private set
            {
                if (string.IsNullOrWhiteSpace(value) || validators.ContainsKey(value.ToLower()) == false)
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }

        }
        public int Weight
        {
            get => weight; 

            private set 
            {
                if (value<1||value>50)
                {
                    throw new Exception($"{toppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double Calories => 2 * weight * validators[toppingType.ToLower()];
    }
}
