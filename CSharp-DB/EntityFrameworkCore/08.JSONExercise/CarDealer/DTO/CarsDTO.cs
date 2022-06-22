using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarsDTO
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public ICollection<int> PartsId { get; set; }
    }
}
//"make": "Opel",
//    "model": "Omega",
//    "travelledDistance": 176664996,
//    "partsId": [