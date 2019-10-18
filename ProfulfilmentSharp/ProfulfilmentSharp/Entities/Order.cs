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

    public class OrderRootResponse
    {
        public OrderRootResponse()
        {
            Order = null;
        }
        public string ValidationError { get; set; }
        public bool IsValid { get; set; }
        public Order Order { get; set; }
    }
}