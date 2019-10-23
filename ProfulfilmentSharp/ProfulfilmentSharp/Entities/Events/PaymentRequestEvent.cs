using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Events
{
    [XmlRoot(ElementName = "orderLine")]
    public class PaymentRequestOrderLine
    {
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
    }

    [XmlRoot(ElementName = "orderLines")]
    public class PaymentRequestOrderLines
    {
        [XmlElement(ElementName = "orderLine")]
        public List<PaymentRequestOrderLine> OrderLine { get; set; }
    }

    [XmlRoot(ElementName = "shipment")]
    public class PaymentRequestShipment
    {
        [XmlElement(ElementName = "orderLines")]
        public PaymentRequestOrderLines OrderLines { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
    }

    [XmlRoot(ElementName = "shipments")]
    public class PaymentRequestShipments
    {
        [XmlElement(ElementName = "shipment")]
        public PaymentRequestShipment Shipment { get; set; }
    }

    [XmlRoot(ElementName = "order")]
    public class PaymentRequestOrder
    {
        [XmlElement(ElementName = "shipments")]
        public PaymentRequestShipments Shipments { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
    }

    [XmlRoot(ElementName = "paymentRequest")]
    public class PaymentRequestEvent
    {
        [XmlElement(ElementName = "order")]
        public PaymentRequestOrder  PaymentRequestOrder{ get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }
}