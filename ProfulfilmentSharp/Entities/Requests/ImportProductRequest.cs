using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
{
    [XmlRoot(ElementName = "import")]
    public class Import
    {
        /// <summary>
        /// product name, for instance : DVD-UNSG
        /// </summary>
        [Required]
        [XmlElement(ElementName = "externalReference")]
        public string ExternalReference { get; set; }

        /// <summary>
        ///  Indicates the operation going to be performed : insert or update
        /// </summary>
        [Required]
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }

        /// <summary>
        ///  description of the product
        /// </summary>
        [Required]
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The ‘logical’ type of the product.Products of different types will be used by the system in different ways.
        /// </summary>
        [Required]
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Denotes what the quantity means for the product. Defaults to ‘unit’ if omitted.
        /// </summary>
        [XmlElement(ElementName = "quantityOnOrder")]
        public string QuantityOnOrder { get; set; }

        /// <summary>
        /// One of a predefined list of values(usually based on ISO 4217) which may be used to control the information shown on customer paperwork. Example : GBP, USD, CNY, EUR
        /// </summary>
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Denotes what the quantity means for the product. Defaults to ‘unit’ if omitted, for instance 'unit', 'weight', 'volume'
        /// </summary>
        [XmlElement(ElementName = "quantityType")]
        public string QuantityType { get; set; }

        /// <summary>
        /// Used to indicate that a product is for sale on one or more channels.
        /// </summary>
        [XmlElement(ElementName = "sellable")]
        public bool Sellable { get; set; }

        /// <summary>
        /// Used to indicate that a product is fragile, usually w.r.t. couriers.
        /// </summary>
        [XmlElement(ElementName = "fragile")]
        public bool Fragile { get; set; }

        /// <summary>   
        /// Used to indicate that a product is considered dangerous, usually w.r.t. couriers.
        /// </summary>
        [XmlElement(ElementName = "dangerous")]
        public bool Dangerous { get; set; }

        /// <summary>
        /// The units to be displayed on the user interfaces for this product, if quantity type is not ‘unit’. Will be abbreviated where appropriate.
        /// for instance 'kilogram', 'gram', 'milligram', 'litre', 'millilitre'
        /// </summary>
        [XmlElement(ElementName = "displayUnits")]
        public string DisplayUnits { get; set; }

        /// <summary>
        /// Text describing how item is packaged and quantity thereof, for instance 'Cartons of 12'
        /// </summary>
        [XmlElement(ElementName = "packagingDescription")]
        public string PackagingDescription { get; set; }

        /// <summary>
        /// The harmonized system (HS) customs code. If not set, can be inferred from product category, for instance '8523.49.5100'
        /// </summary>
        [XmlElement(ElementName = "harmonisedSystemCode")]
        public string HarmonisedSystemCode { get; set; }

        /// <summary>
        /// Typically for customs declarations.ISO code or full country name.   
        /// </summary>
        [XmlElement(ElementName = "countryOfOrigin")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// The description of the product for customs paperwork. If not set, can be inferred from product category
        /// </summary>
        [XmlElement(ElementName = "customsDescription")]
        public string CustomsDescription { get; set; }

        /// <summary>
        /// Typically used for customs purposes.
        /// </summary>
        [XmlElement(ElementName = "productComposition")]
        public string ProductComposition { get; set; }

        /// <summary>
        /// A comma-separated list of the physical storage types which are used to hold products of this type
        /// </summary>
        [XmlElement(ElementName = "physicalStorageTypes")]
        public string PhysicalStorageTypes { get; set; }

        [XmlElement(ElementName = "weight")] public double? Weight { get; set; }
        [XmlElement(ElementName = "barcode")] public string Barcode { get; set; }

        [XmlElement(ElementName = "weightUnits")]
        public string WeightUnits { get; set; }

        [XmlElement(ElementName = "priceNet")] public double? PriceNet { get; set; }

        [XmlElement(ElementName = "priceGross")]
        public double? PriceGross { get; set; }

        [XmlElement(ElementName = "tax")] public double? Tax { get; set; }
        [XmlElement(ElementName = "taxCode")] public string TaxCode { get; set; }

        [XmlElement(ElementName = "currencyUnits")]
        public string CurrencyUnits { get; set; }

        [XmlElement(ElementName = "costNet")] public string CostNet { get; set; }

        [XmlElement(ElementName = "costGross")]
        public string CostGross { get; set; }

        [XmlElement(ElementName = "costTax")] public double? CostTax { get; set; }

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

        [XmlElement(ElementName = "length")] public double? Length { get; set; }
        [XmlElement(ElementName = "width")] public double? Width { get; set; }
        [XmlElement(ElementName = "height")] public double? Height { get; set; }
        [XmlElement(ElementName = "area")] public double? Area { get; set; }

        [XmlElement(ElementName = "PickingInstruction")]
        public string PickingInstruction { get; set; }

        [XmlElement(ElementName = "packingInstruction")]
        public string PackingInstruction { get; set; }

        /// <summary>
        /// Can be derived from dimensions if not supplied
        /// </summary>
        [XmlElement(ElementName = "volume")]
        public double? Volume { get; set; }

        /// <summary>
        /// for instance 'red'
        /// </summary>
        [XmlElement(ElementName = "colour")]
        public string Colour { get; set; }

        /// <summary>
        /// for instance 'XL'
        /// </summary>
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
    }

    [XmlRoot(ElementName = "imports")]
    public class ImportProductRequest
    {
        [XmlElement(ElementName = "import")] public Import Import { get; set; }
    }
}