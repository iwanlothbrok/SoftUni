
using System.Xml.Serialization;

namespace CarDealer.OutputDtos
{
    [XmlType("suplier")]
    public class LocalSuppliesDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
       
    }
}
//<? xml version = "1.0" encoding = "utf-16" ?>
//   < suppliers >
   
//     < suplier id = "2" name = "VF Corporation" parts - count = "3" />
        
//          < suplier id = "5" name = "Saks Inc" parts - count = "2" />
//               ...
