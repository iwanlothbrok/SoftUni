using CarRacing.Models.Cars.Contracts;
using System;
using System.Text;

namespace CarRacing.Models.Racers.Contracts
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;


        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;

        }

        public string Username
        {
            get { return username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                username = value;
            }
        }


        public string RacingBehavior
        {
            get { return racingBehavior; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                racingBehavior = value;
            }
        }


        public int DrivingExperience
        {
            get { return drivingExperience; }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                drivingExperience = value;
            }
        }


        public ICar Car
        {
            get { return car; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                car = value;
            }
        }



        public bool IsAvailable() // CHECK IF ITS RIGHT
        {
            if (car.FuelAvailable < 0)
            {
                return false;
            }
            return true;
        }

        public void Race()
        {
            car.Drive();
            this.DrivingExperience += 5;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {car.Make} {car.Model} ({car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
