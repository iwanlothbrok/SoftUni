using System.Xml.Serialization;

namespace CarDealer.InputDtos
{
    [XmlType("Sale")]

    public class SalesDTO
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }
    }
}
//[XmlType("Customer")]
//[XmlElement("name")] 
//< Sales >
//    < Sale >
//        < carId > 105 </ carId >
//        < customerId > 30 </ customerId >
//        < discount > 30 </ discount >
//    </ Sale >