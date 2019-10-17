using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlAttribute(AttributeName = "inventoryId")]
        public string InventoryId { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "site")]
        public string Site { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "allocated")]
        public string Allocated { get; set; }
        [XmlAttribute(AttributeName = "available")]
        public string Available { get; set; }
        [XmlAttribute(AttributeName = "frozen")]
        public string Frozen { get; set; }
        [XmlAttribute(AttributeName = "inspection")]
        public string Inspection { get; set; }
        [XmlAttribute(AttributeName = "damaged")]
        public string Damaged { get; set; }
        [XmlAttribute(AttributeName = "quarantined")]
        public string Quarantined { get; set; }
        [XmlAttribute(AttributeName = "onOrder")]
        public string OnOrder { get; set; }
        [XmlAttribute(AttributeName = "lastStockChangeId")]
        public string LastStockChangeId { get; set; }
        [XmlAttribute(AttributeName = "lastLineRequirementChangeId")]
        public string LastLineRequirementChangeId { get; set; }
    }
}