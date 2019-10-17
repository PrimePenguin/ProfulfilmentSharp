using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    public class ImportOrderLineItem
    {
        [XmlElement(ElementName = "orderLine.1.product.externalReference")]
        public string ProductExternalReference { get; set; }

        [XmlElement(ElementName = "orderLine.1.quantity")]
        public string Quantity { get; set; }

        [XmlElement(ElementName = "orderLine.1.state")]
        public string State { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalPriceNet")]
        public float TotalPriceNet { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalPriceGross")]
        public float TotalPriceGross { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalTax")]
        public float TotalTax { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalTaxCode")]
        public string TotalTaxCode { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitPriceNet")]
        public float UnitPriceNet { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitPriceGross")]
        public float UnitPriceGross { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitTax")]
        public float UnitTax { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitTaxCode")]
        public string UnitTaxCode { get; set; }

        [XmlElement(ElementName = "orderLine.1.userDefined1")]
        public string UserDefined1 { get; set; }

        [XmlElement(ElementName = "orderLine.1.userDefined2")]
        public string UserDefined2 { get; set; }

        [XmlElement(ElementName = "orderLine.1.userDefined3")]
        public string UserDefined3 { get; set; }

        [XmlElement(ElementName = "orderLine.1.userDefined4")]
        public string UserDefined4 { get; set; }

        [XmlElement(ElementName = "orderLine.1.userDefined5")]
        public string UserDefined5 { get; set; }

        [XmlElement(ElementName = "orderLine.1.shipment")]
        public string Shipment { get; set; }

        [XmlElement(ElementName = "orderAttribute.1.name")]
        public string AttributeName { get; set; }

        [XmlElement(ElementName = "orderAttribute.1.title")]
        public string AttributeTitle { get; set; }

        [XmlElement(ElementName = "orderAttribute.1.value")]
        public string AttributeValue { get; set; }

        [XmlElement(ElementName = "orderAttribute.1.orderItem")]
        public string OrderItem { get; set; }
    }
}