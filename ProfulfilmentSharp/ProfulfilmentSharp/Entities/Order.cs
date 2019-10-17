using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "shipments")]
        public Shipments Shipments { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
    }
}