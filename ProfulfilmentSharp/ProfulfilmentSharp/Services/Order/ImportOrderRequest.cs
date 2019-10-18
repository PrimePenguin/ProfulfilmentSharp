using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "import")]
    public class ImportOrderRequest
    {
        [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }

        [Required]
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }

        [XmlElement(ElementName = "state")]
        public string State { get; set; }

        [XmlElement(ElementName = "validated")]
        public bool Validated { get; set; }

        [XmlElement(ElementName = "paymentTransactionInfo")]
        public string PaymentTransactionInfo { get; set; }

        [XmlElement(ElementName = "customerComment")]
        public string CustomerComment { get; set; }

        [XmlElement(ElementName = "totalPriceNet")]
        public float TotalPriceNet { get; set; }

        [XmlElement(ElementName = "totalPriceGross")]
        public float TotalPriceGross { get; set; }

        [XmlElement(ElementName = "totalTax")]
        public float TotalTax { get; set; }

        [XmlElement(ElementName = "totalTaxCode")]
        public string TotalTaxCode { get; set; }

        [XmlElement(ElementName = "shippingPriceNet")]
        public float ShippingPriceNet { get; set; }

        [XmlElement(ElementName = "shippingPriceGross")]
        public float ShippingPriceGross { get; set; }

        [XmlElement(ElementName = "shippingTax")]
        public float ShippingTax { get; set; }

        [XmlElement(ElementName = "shippingTaxCode")]
        public string ShippingTaxCode { get; set; }

        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }

        [XmlElement(ElementName = "currencyUnits")]
        public string CurrencyUnits { get; set; }

        [XmlElement(ElementName = "placed")]
        public string Placed { get; set; }

        [XmlElement(ElementName = "authorised")]
        public string Authorised { get; set; }

        [XmlElement(ElementName = "source")]
        public string Source { get; set; }

        [XmlElement(ElementName = "userDefined1")]
        public string UserDefined1 { get; set; }

        [XmlElement(ElementName = "userDefined2")]
        public string UserDefined2 { get; set; }

        [XmlElement(ElementName = "userDefined3")]
        public string UserDefined3 { get; set; }

        [XmlElement(ElementName = "userDefined4")]
        public string UserDefined4 { get; set; }

        [XmlElement(ElementName = "userDefined5")]
        public string UserDefined5 { get; set; }

        [XmlElement(ElementName = "Delivery")] public ImportOrderDelivery Delivery { get; set; }

        [XmlElement(ElementName = "Invoice")] public ImportOrderInvoice Invoice { get; set; }

        [XmlElement(ElementName = "shipment")] public ImportOrderShipment Shipment { get; set; }

        [XmlElement(ElementName = "lineItem")] public List<ImportOrderLineItem> LineItems { get; set; }
    }
}