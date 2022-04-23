using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Contracts
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            Pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get { return raceName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: { RaceName }.");//again check the value 
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
             set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: { NumberOfLaps }.");//again check the value 
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots { get; set; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookPlaceResult = string.Empty;
            if (TookPlace == true)
            {
                tookPlaceResult = "Yes";
            }
            else
            {
                tookPlaceResult = "No";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The { RaceName } race has:");
            sb.AppendLine($"Participants: {Pilots.Count }");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine($"Took place: { TookPlace }");//if true: yes ?: no
            return sb.ToString().TrimEnd();
        }
    }
}
