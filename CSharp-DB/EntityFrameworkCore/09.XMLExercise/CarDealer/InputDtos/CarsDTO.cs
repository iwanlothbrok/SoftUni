using System.Collections;
using System.Xml.Serialization;

namespace CarDealer.InputDtos
{
    [XmlType(TypeName = "Car")]

    public class CarsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]

        public long TravelDistance { get; set; }

        [XmlArray("parts")]
        public CarsPartsDTO[] Parts { get; set; } // list?
    }
}
//< Car >
//  < make > Opel </ make >
//  < model > Omega </ model >
//  < TraveledDistance > 176664996 </ TraveledDistance >
//  < parts >
//    < partId id = "38" />

//     < partId id = "102" />

//      < partId id = "23" />

//       < partId id = "116" />

//        < partId id = "46" />