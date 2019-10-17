using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "shipments")]
    public class Shipments
    {
        [XmlElement(ElementName = "shipment")]
        public Shipment Shipment { get; set; }
    }
}