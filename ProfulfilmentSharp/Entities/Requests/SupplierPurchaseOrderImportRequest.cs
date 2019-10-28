using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
{
    [XmlRoot(ElementName = "import")]
    public class PurchaseOrderRequest
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }

        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }

        [XmlElement(ElementName = "purchaseOrder.supplierReference")]
        public string SupplierReference { get; set; }

        [XmlElement(ElementName = "purchaseOrder.supplier")]
        public string Supplier { get; set; }

        [XmlElement(ElementName = "purchaseOrder.site")]
        public string Site { get; set; }

        [XmlElement(ElementName = "purchaseOrder.campaign")]
        public string Campaign { get; set; }

        [XmlElement(ElementName = "purchaseOrder.products")]
        public List<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
    }

    public class PurchaseOrderProduct
    {
        public string Product { get; set; }
        public float Quantity { get; set; }
        public string PurchaseOrder { get; set; }
        public string ProductExternalReference { get; set; }
    }

    [XmlRoot(ElementName = "imports")]
    public class SupplierPurchaseOrderImportRequest
    {
        [XmlElement(ElementName = "import")] public PurchaseOrderRequest PurchaseOrder { get; set; }
    }
}