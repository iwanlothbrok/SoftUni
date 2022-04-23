using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;

namespace Formula1.Core.Contracts
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;


        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();  //check if its correct 
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var needPilot = pilotRepository.FindByName(pilotName);
            var needCar = carRepository.FindByName(carModel);

            if (needPilot == null || needPilot.CanRace == true)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }
            if (needCar == null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }
            //  Pilot pilot = new Pilot(pilotName);
            needPilot.AddCar(needCar);
            //needPilot.CanRace=true;
            carRepository.Remove(needCar);
            return $"Pilot { pilotName } will drive a {needCar.GetType().Name} { carModel } car."; //TODO : CHECK THIS VALUES 

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var needPilot = pilotRepository.FindByName(pilotFullName);
            var needRace = raceRepository.FindByName(raceName);

            if (needPilot == null || needPilot.CanRace == false)//check if its in race ?
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }
            if (needRace == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            var race = raceRepository.FindByName(raceName);

            //if (raceRepository.Models.Contains(needPilot))
            if (race.Pilots.Contains(needPilot))
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }
            



            needRace.AddPilot(needPilot);
            return $"Pilot { pilotFullName } is added to the { raceName } race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null;
            var searchedModel = carRepository.FindByName(model);
            if (searchedModel != null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            carRepository.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            //pilotRepository = new PilotRepository();
            var neededPilot = pilotRepository.FindByName(fullName);


            if (neededPilot != null)
            {
                throw new InvalidOperationException($"Pilot { fullName } is already created.");
            }
            Pilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return $"Pilot { fullName } is created.";

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            Race race = null;
            var neededRace = raceRepository.FindByName(raceName);
            // if (raceRepository.Count == 0)
            // {
            //      race = new Race(raceName, numberOfLaps);
            //     raceRepository.Add(race);
            //     return $"Race { raceName } is created.";
            // }
            if (neededRace != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }

            race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();

        }

        public string RaceReport()
        {
            //Remove everything in this method
            var sb = new StringBuilder();
            var race = this.raceRepository.Models.Where(a => a.TookPlace == true);


            foreach (var raceInfo in race)
            {

                Race r = new Race(raceInfo.RaceName, raceInfo.NumberOfLaps);
                r.Pilots = raceInfo.Pilots;
                r.TookPlace = raceInfo.TookPlace;

                sb.AppendLine(r.RaceInfo());

            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var neededRace = raceRepository.FindByName(raceName);
            if (neededRace == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if (neededRace.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race { raceName } cannot start with less than three participants.");
            }
            if (neededRace.TookPlace == true)//TODO:check if it was executed 
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }
            int count = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in neededRace.Pilots.OrderByDescending(n => n.Car.RaceScoreCalculator(neededRace.NumberOfLaps)).ThenBy(n => n.FullName))
            {
                if (count == 0)
                {
                    sb.AppendLine($"Pilot { item.FullName } wins the { neededRace.RaceName  } race.");
                    item.WinRace();
                }
                else if (count == 1)
                {
                    sb.AppendLine($"Pilot { item.FullName } is second in the { neededRace.RaceName  } race.");
                }
                else if (count == 2)
                {
                    sb.AppendLine($"Pilot {  item.FullName  } is third in the {neededRace.RaceName  } race.");
                }
                if (count == 3)
                {
                    break;
                }
                count++;
            }
            neededRace.TookPlace = true;
            return sb.ToString().TrimEnd();
        }
    }
}
