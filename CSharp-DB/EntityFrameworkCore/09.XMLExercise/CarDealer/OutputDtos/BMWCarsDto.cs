using System.Xml.Serialization;

namespace CarDealer.OutputDtos
{
    [XmlType("car")]
    public class BMWCarsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelDistance { get; set; }
    }
}
