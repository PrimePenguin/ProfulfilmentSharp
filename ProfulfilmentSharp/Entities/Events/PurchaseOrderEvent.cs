using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Events
{
    [XmlRoot(ElementName = "purchaseOrderLine")]
    public class PurchaseOrderLine
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "outstanding")]
        public string Outstanding { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
    }

    [XmlRoot(ElementName = "purchaseOrderLines")]
    public class PurchaseOrderLines
    {
        [XmlElement(ElementName = "purchaseOrderLine")]
        public List<PurchaseOrderLine> PurchaseOrderLine { get; set; }
    }

    [XmlRoot(ElementName = "deliveryLine")]
    public class PurchaseOrderDeliveryLine
    {
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

    [XmlRoot(ElementName = "deliveryLines")]
    public class PurchaseOrderDeliveryLines
    {
        [XmlElement(ElementName = "deliveryLine")]
        public List<PurchaseOrderDeliveryLine> DeliveryLine { get; set; }
    }

    [XmlRoot(ElementName = "delivery")]
    public class PurchaseOrderDelivery
    {
        [XmlElement(ElementName = "deliveryLines")]
        public PurchaseOrderDeliveryLines DeliveryLines { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
        [XmlAttribute(AttributeName = "supplierDeliveryReference")]
        public string SupplierDeliveryReference { get; set; }
        [XmlAttribute(AttributeName = "deliveryDate")]
        public string DeliveryDate { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string Created { get; set; }
        [XmlAttribute(AttributeName = "completed")]
        public string Completed { get; set; }
    }

    [XmlRoot(ElementName = "deliveries")]
    public class PurchaseOrderDeliveries
    {
        [XmlElement(ElementName = "delivery")]
        public PurchaseOrderDelivery Delivery { get; set; }
    }

    [XmlRoot(ElementName = "purchaseOrder")]
    public class PurchaseOrderDetails
    {
        [XmlElement(ElementName = "note")]
        public string Note { get; set; }
        [XmlElement(ElementName = "purchaseOrderLines")]
        public PurchaseOrderLines PurchaseOrderLines { get; set; }
        [XmlElement(ElementName = "deliveries")]
        public PurchaseOrderDeliveries Deliveries { get; set; }
        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
        [XmlAttribute(AttributeName = "organisation")]
        public string Organisation { get; set; }
        [XmlAttribute(AttributeName = "site")]
        public string Site { get; set; }
        [XmlAttribute(AttributeName = "supplierReference")]
        public string SupplierReference { get; set; }
        [XmlAttribute(AttributeName = "supplierPurchaseOrderReference")]
        public string SupplierPurchaseOrderReference { get; set; }
        [XmlAttribute(AttributeName = "manuallyCompleted")]
        public string ManuallyCompleted { get; set; }
        [XmlAttribute(AttributeName = "purchaseOrderDate")]
        public string PurchaseOrderDate { get; set; }
    }

    [XmlRoot(ElementName = "detail")]
    public class Detail
    {
        [XmlElement(ElementName = "purchaseOrder")]
        public PurchaseOrderDetails PurchaseOrder { get; set; }
    }

    [XmlRoot(ElementName = "event")]
    public class PurchaseOrderEvent
    {
        [XmlElement(ElementName = "detail")]
        public Detail Detail { get; set; }
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