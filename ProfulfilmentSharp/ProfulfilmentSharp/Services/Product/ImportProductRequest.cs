using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "import")]
    public class Import
    {
        [XmlElement(ElementName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string _ExternalReference { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "weight")]
        public float Weight { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string _Type { get; set; }
        [XmlElement(ElementName = "quantityOnOrder")]
        public string QuantityOnOrder { get; set; }
        [XmlElement(ElementName = "priceNet")]
        public float PriceNet { get; set; }
        [XmlElement(ElementName = "priceGross")]
        public float PriceGross { get; set; }
        [XmlElement(ElementName = "tax")]
        public float Tax { get; set; }
        [XmlElement(ElementName = "taxCode")]
        public float TaxCode { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "currencyUnits")]
        public string CurrencyUnits { get; set; }
        [XmlElement(ElementName = "costNet")]
        public string CostNet { get; set; }
        [XmlElement(ElementName = "costGross")]
        public string CostGross { get; set; }
        [XmlElement(ElementName = "costTax")]
        public string CostTax { get; set; }
        [XmlElement(ElementName = "costTaxCode")]
        public string CostTaxCode { get; set; }
        [XmlElement(ElementName = "costCurrency")]
        public string CostCurrency { get; set; }
        [XmlElement(ElementName = "costCurrencyUnits")]
        public string CostCurrencyUnits { get; set; }
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
        [XmlElement(ElementName = "activated")]
        public string Activated { get; set; }

        /// <summary>
        ///  insert or update
        /// </summary>
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
    }

    [XmlRoot(ElementName = "imports")]
    public class ImportProductRequest
    {
        [XmlElement(ElementName = "import")] public Import Import { get; set; }
    }
}