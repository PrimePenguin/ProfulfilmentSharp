using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "orderLines")]
    public class OrderLines
    {
        [XmlElement(ElementName = "orderLine")]
        public OrderLine OrderLine { get; set; }
    }
}
