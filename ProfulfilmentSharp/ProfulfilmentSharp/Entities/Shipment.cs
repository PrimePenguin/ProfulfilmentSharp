using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "shipment")]
    public class Shipment
    {
        [XmlElement(ElementName = "orderLines")]
        public OrderLines OrderLines { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "earliestShipDate")]
        public string EarliestShipDate { get; set; }
        [XmlAttribute(AttributeName = "courier")]
        public string Courier { get; set; }
    }
}