using System;

namespace Formula1.Models.Contracts
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return model; }
             set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <3)
                {
                    throw new ArgumentException($"Invalid car model: {Model}.");//CHECK VALUE/ MODEL 
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
             set
            {   
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: { Horsepower }.");//CHECK VALUE/ HORSEPOWER 

                }
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
             set
            {
                if (value < 1.6 || value > 2.0)
                {
                    throw new ArgumentException($"Invalid car engine displacement: { EngineDisplacement }.");//CHECK VALUE/ EngineDisplacement 

                }
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            //engine displacement / horsepower * laps
            return EngineDisplacement / (Horsepower * laps);
        }
    }
}
