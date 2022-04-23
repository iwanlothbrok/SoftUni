using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers.Contracts
{
    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car) : base(username, "strict", 30, car)
        {
        }
        public void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
