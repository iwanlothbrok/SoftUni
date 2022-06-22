using System.Xml.Serialization;

namespace CarDealer.OutputDtos
{
    [XmlType(TypeName = "car")]

    public class OutputCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]

        public long TravelDistance { get; set; }

        
       
    }
}

