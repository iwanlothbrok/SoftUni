
using System;
using System.Collections.Generic;

namespace p04PizzaCalories
{
    public class Dough
    {
        //    White - 1.5 
        //Wholegrain - 1.0
        //Crispy - 0.9
        //Chewy - 1.1
        //Homemade - 1.0
        private string flourType;
        private string bakingTechnique;
        private int weight;


        private readonly Dictionary<string, double> validator = new Dictionary<string, double>()
        {
            {"white",1.5 },
            {"wholegrain",1.0 },
            {"crispy",0.9 },
            {"chewy",1.1 },
            {"homemade",1.0 }
        };
        public Dough(string flourType,string bakingTechnique,int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get =>  flourType; 

           private set 
            {
                if (validator.ContainsKey(value.ToLower()) == false)
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value; 
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            
            private set
            {
                if (validator.ContainsKey(value.ToLower())==false)
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public int Weight
        {
            get { return weight; }
            set 
            {
                if (value>200 || value<1)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }
                weight = value;
            }
        }
        public double Calories => 2 * Weight *
            validator[BakingTechnique.ToLower()] * validator[FlourType.ToLower()];

    }
}
