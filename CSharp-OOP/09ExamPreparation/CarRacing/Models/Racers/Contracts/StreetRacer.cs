﻿using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers.Contracts
{
    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car) : base(username, "aggressive", 10, car)
        {
        }
      
    }
}