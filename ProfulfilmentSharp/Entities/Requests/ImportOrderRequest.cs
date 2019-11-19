using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
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

        /// <summary>
        /// One of a predefined list of values which may be used to control how an order is processed.Normally, it is best not to set this value, instead leaving this job to the OrderFlow import mapping script, for instance 'created'
        /// </summary>
        [XmlElement(ElementName = "state")]
        public string State { get; set; }

        [XmlElement(ElementName = "validated")]
        public bool Validated { get; set; }

        /// <summary>
        /// for instance, 'Environment dependent'
        /// </summary>
        [XmlElement(ElementName = "paymentTransactionInfo")]
        public string PaymentTransactionInfo { get; set; }

        [XmlElement(ElementName = "customerComment")]
        public string CustomerComment { get; set; }

        [XmlElement(ElementName = "totalPriceNet")]
        public double?  TotalPriceNet { get; set; }

        [XmlElement(ElementName = "totalPriceGross")]
        public double?  TotalPriceGross { get; set; }

        [XmlElement(ElementName = "totalPriceTax")]
        public double?  TotalPriceTax { get; set; }

        [XmlElement(ElementName = "totalTax")] public double?  TotalTax { get; set; }

        /// <summary>
        /// pass a payment gateway identifier to OrderFlow, if required, for instance 'google_checkout'
        /// </summary>
        [XmlElement(ElementName = "paymentGatewayIdentifier")]
        public string PaymentGatewayIdentifier { get; set; }

        /// <summary>
        /// Flag indicating whether order has been divided upstream of OrderFlow
        /// </summary>
        [XmlElement(ElementName = "partialOrder")]
        public bool PartialOrder { get; set; }

        /// <summary>
        /// One of a list of values which may be used to control the information shown on customer paperwork, for instance 'T0', 'T1', 'T2'
        /// </summary>
        [XmlElement(ElementName = "totalTaxCode")]
        public string TotalTaxCode { get; set; }

        /// <summary>
        /// The net amount for the shipping charge for the order
        /// </summary>
        [XmlElement(ElementName = "shippingPriceNet")]
        public double?  ShippingPriceNet { get; set; }

        [XmlElement(ElementName = "shippingPriceGross")]
        public double?  ShippingPriceGross { get; set; }

        [XmlElement(ElementName = "shippingTax")]
        public double?  ShippingTax { get; set; }

        [XmlElement(ElementName = "shippingTaxTotal")]
        public double?  ShippingTaxTotal { get; set; }

        /// <summary>
        /// The price for the goods in the order. Includes the goods portion of the shipping price; excluding the shipping price
        /// </summary>
        [XmlElement(ElementName = "goodsPriceNet")]
        public double?  GoodsPriceNet { get; set; }

        [XmlElement(ElementName = "goodsPriceGross")]
        public double?  GoodsPriceGross { get; set; }

        [XmlElement(ElementName = "goodsTax")] public double?  GoodsTax { get; set; }

        /// <summary>
        /// One of a list of values which may be used to control the information shown on customer paperwork, for instance 'T0', 'T1', 'T2'
        /// </summary>
        [XmlElement(ElementName = "goodTaxCode")]
        public string GoodTaxCode { get; set; }

        /// <summary>
        /// One of a list of values which may be used to control the information shown on customer paperwork, for instance 'T0', 'T1', 'T2'
        /// </summary>
        [XmlElement(ElementName = "shippingTaxCode")]
        public string ShippingTaxCode { get; set; }

        /// <summary>
        /// One of a predefined list of values (usually based on ISO 4217) which may be used to control the information shown on customer paperwork,
        /// for instance 'GBP', 'EUR', 'USD', 'CNY'
        /// </summary>
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// One of a predefined list of values which may be used at the point the order is imported, for instance 'pounds'
        /// </summary>
        [XmlElement(ElementName = "currencyUnits")]
        public string CurrencyUnits { get; set; }

        /// <summary>
        /// The promotion code for the order if present
        /// </summary>
        [XmlElement(ElementName = "promotionCode")]
        public string PromotionCode { get; set; }

        /// <summary>
        /// The description of the promotion
        /// </summary>
        [XmlElement(ElementName = "promotionDescription")]
        public string PromotionDescription { get; set; }

        /// <summary>
        /// TIMESTAMP Time the order was placed by the customer. for instance '2019-11-31 13:24:06'
        /// </summary>
        [XmlElement(ElementName = "placed")]
        public string Placed { get; set; }

        /// <summary>
        /// TIMESTAMP Time the payment was approved (typically by a payment gateway)
        /// </summary>
        [XmlElement(ElementName = "authorised")]
        public string Authorised { get; set; }

        /// <summary>
        /// A string which identifies the original source of the order. Can be used within OrderFlow to remap order to a different channel.
        /// </summary>
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