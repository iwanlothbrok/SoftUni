using System;
using System.Xml.Serialization;

namespace CarDealer.InputDtos
{
    [XmlType("Customer")]

    public class CustomersDTO
    {
       
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
//<? xml version = "1.0" encoding = "UTF-8" ?>
//   < Customers >

//       < Customer >

//           < name > Emmitt Benally </ name >

//           < birthDate > 1993 - 11 - 20T00: 00:00 </ birthDate >

//                   < isYoungDriver > true </ isYoungDriver >

//               </ Customer >