using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "orderLine")]
    public class OrderLine
    {
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
    }
}