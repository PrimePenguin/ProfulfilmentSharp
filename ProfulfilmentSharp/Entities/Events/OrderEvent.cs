using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Events
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

    [XmlRoot(ElementName = "orderLines")]
    public class OrderLines
    {
        [XmlElement(ElementName = "orderLine")]
        public List<OrderLine> OrderLine { get; set; }
    }

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
        [XmlAttribute(AttributeName = "despatchReference")]
        public string DespatchReference { get; set; }
    }

    [XmlRoot(ElementName = "shipments")]
    public class Shipments
    {
        [XmlElement(ElementName = "shipment")]
        public Shipment Shipment { get; set; }
    }

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

    [XmlRoot(ElementName = "detail")]
    public class OrderEventDetails
    {
        [XmlElement(ElementName = "order")]
        public Order Order { get; set; }
    }

    [XmlRoot(ElementName = "event")]
    public class OrderEvent
    {
        [XmlElement(ElementName = "detail")]
        public OrderEventDetails Detail { get; set; }
        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }
        [XmlAttribute(AttributeName = "eventType")]
        public string EventType { get; set; }
        [XmlAttribute(AttributeName = "userName")]
        public string UserName { get; set; }
        [XmlAttribute(AttributeName = "eventTime")]
        public string EventTime { get; set; }
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
    }
}