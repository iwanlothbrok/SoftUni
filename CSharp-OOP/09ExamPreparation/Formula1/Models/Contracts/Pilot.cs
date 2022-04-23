using System;

namespace Formula1.Models.Contracts
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }
        public string FullName
        {
            get { return fullName; }
             set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: { FullName }.");//check all props setter value using
                }
                fullName = value;
            }

        }
        public bool CanRace { get; set; } = false;

        public IFormulaOneCar Car
        {
            get { return car; }
             set
            {
                if (value == null)
                {
                    throw new NullReferenceException($"Pilot car can not be null.");
                }
                car = value;
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
             set { numberOfWins = value; }
        }


        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            this.CanRace = true;

        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot { FullName} has { NumberOfWins } wins.";
        }
    }
}
