using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class ImportOrderLineItem
    {
        [Required]
        [XmlElement(ElementName = "orderLine.1.product.externalReference")]
        public string ProductExternalReference { get; set; }

        [Required]
        [XmlElement(ElementName = "orderLine.1.quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Typically used for a local language order line description. If not set, then product description is used instead
        /// </summary>
        [XmlElement(ElementName = "orderLine.1.description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalPriceNet")]
        public double?  TotalPriceNet { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalTax")]
        public double? TotalTax { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalTaxCode")]
        public double? TotalTaxCode { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitPriceNet")]
        public double? UnitPriceNet { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitPriceGross")]
        public double? UnitPriceGross { get; set; }

        [XmlElement(ElementName = "orderLine.1.unitTax")]
        public double? UnitTax { get; set; }

        [XmlElement(ElementName = "orderLine.1.totalPriceGross")]
        public double?  TotalPriceGross { get; set; }

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