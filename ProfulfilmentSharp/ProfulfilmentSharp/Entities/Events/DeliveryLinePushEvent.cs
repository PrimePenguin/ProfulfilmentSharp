using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Events
{
    [XmlRoot(ElementName = "delivery")]
    public class DeliveryLineInfo
    {
        [XmlElement(ElementName = "purchaseOrder")]
        public PurchaseOrder PurchaseOrder { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
        [XmlAttribute(AttributeName = "site")]
        public string Site { get; set; }
        [XmlAttribute(AttributeName = "organisation")]
        public string Organisation { get; set; }
        [XmlAttribute(AttributeName = "supplierReference")]
        public string SupplierReference { get; set; }
        [XmlAttribute(AttributeName = "supplierDeliveryReference")]
        public string SupplierDeliveryReference { get; set; }
        [XmlAttribute(AttributeName = "deliveryDate")]
        public string DeliveryDate { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string Created { get; set; }
    }

    [XmlRoot(ElementName = "deliveryLine")]
    public class DeliveryLineItem
    {
        [XmlElement(ElementName = "delivery")]
        public DeliveryLineInfo Delivery { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }
        [XmlAttribute(AttributeName = "variation")]
        public string Variation { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
    }

    [XmlRoot(ElementName = "detail")]
    public class DeliveryLinePushDetails
    {
        [XmlElement(ElementName = "deliveryLine")]
        public DeliveryLineItem DeliveryLine { get; set; }
    }

    [XmlRoot(ElementName = "event")]
    public class DeliveryLinePushEvent
    {
        [XmlElement(ElementName = "detail")]
        public DeliveryLinePushDetails Detail { get; set; }
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
    }
}