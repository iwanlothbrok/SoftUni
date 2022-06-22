using System.Xml.Serialization;

namespace CarDealer.InputDtos
{
    [XmlType("partId")]
    public class CarsPartsDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
} 