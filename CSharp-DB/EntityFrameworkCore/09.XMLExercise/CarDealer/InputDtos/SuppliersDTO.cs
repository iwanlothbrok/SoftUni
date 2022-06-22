using System.Xml.Serialization;

namespace CarDealer.InputDtos
{
    [XmlType(TypeName = "Supplier")]
    public class SuppliersDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
//< Suppliers >
//    < Supplier >
//        < name > 3M Company </ name >
   
//           < isImporter > true </ isImporter >
   
//       </ Supplier >
   
//       < Supplier >