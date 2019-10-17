using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "shipment")]
    public class DispatchedShipment
    {
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "orderReference")]
        public string OrderReference { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }
        [XmlElement(ElementName = "courier")]
        public string Courier { get; set; }
        [XmlElement(ElementName = "carrier")]
        public string Carrier { get; set; }
        [XmlElement(ElementName = "service")]
        public string Service { get; set; }
        [XmlElement(ElementName = "despatchReference")]
        public string DespatchReference { get; set; }
        [XmlElement(ElementName = "completed")]
        public string Completed { get; set; }
        [XmlElement(ElementName = "packages")]
        public Packages Packages { get; set; }
    }
}