using CarRacing.Models.Racers.Contracts;
using System.Text;

namespace CarRacing.Models.Maps.Contracts
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo} wins the race! {racerOne} was not available to race!";
            }
            if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne} wins the race! {racerTwo} was not available to race!";
            }
            racerOne.Race();
            racerTwo.Race();

            StringBuilder sb = new StringBuilder();

            double pointRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                pointRacerOne *= 1.2;
            }
            else
            {
                pointRacerOne *= 1.1;
            }


            double pointForSecondRacer = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerTwo.RacingBehavior == "strict")
            {
                pointForSecondRacer *= 1.2;
            }
            else
            {
                pointForSecondRacer *= 1.1;
            }

            sb.Append($"{racerOne.Username} has just raced against {racerTwo.Username}!");
            if (pointRacerOne > pointForSecondRacer)
            {
                sb.Append($" {racerOne.Username} is the winner!");
            }
            else
            {
                sb.Append($" {racerTwo.Username} is the winner!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
