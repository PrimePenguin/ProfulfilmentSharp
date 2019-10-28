using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "inventory")]
    public class Inventory
    {
        [XmlElement(ElementName = "product")] public List<Product> Products { get; set; }
    }
}