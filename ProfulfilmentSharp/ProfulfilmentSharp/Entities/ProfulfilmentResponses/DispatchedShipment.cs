using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.ProfulfilmentRequests
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

        [XmlElement(ElementName = "orderLines")]
        public DispatchedOrderLines OrderLines { get; set; }
    }

    [XmlRoot(ElementName = "orderLines")]
    public class DispatchedOrderLines
    {
        [XmlElement(ElementName = "orderLine")]
        public List<DispatchedOrderLine> OrderLines { get; set; }
    }

    [XmlRoot(ElementName = "orderLine")]    
    public class DispatchedOrderLine
    {
        [XmlElement(ElementName = "productReference")]
        public string ProductReference { get; set; }
        [XmlElement(ElementName = "quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "thirdPartyReference")]
        public string ThirdPartyReference { get; set; }
    }
}