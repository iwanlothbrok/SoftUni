﻿namespace p06FoodShortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
          
        }

        public string Name { get;private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public int Food {get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
