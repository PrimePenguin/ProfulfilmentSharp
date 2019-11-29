using System.Collections.Generic;
using System.Security.Principal;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Responses
{
    [XmlRoot(ElementName = "line")]
    public class Line
    {
        [XmlElement(ElementName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlElement(ElementName = "poReference")]
        public string PoReference { get; set; }
        [XmlElement(ElementName = "poState")]
        public string PoState { get; set; }
        [XmlElement(ElementName = "supplier")]
        public string Supplier { get; set; }
        [XmlElement(ElementName = "supplierReference")]
        public string SupplierReference { get; set; }
        [XmlElement(ElementName = "poDate")]
        public string PoDate { get; set; }
        [XmlElement(ElementName = "poCreated")]
        public string PoCreated { get; set; }
        [XmlElement(ElementName = "poLastUpdated")]
        public string PoLastUpdated { get; set; }
        [XmlElement(ElementName = "poCompleted")]
        public string PoCompleted { get; set; }
        [XmlElement(ElementName = "lineQuantity")]
        public string LineQuantity { get; set; }
        [XmlElement(ElementName = "lineOutstandingQuantity")]
        public string LineOutstandingQuantity { get; set; }
        [XmlElement(ElementName = "lineState")]
        public string LineState { get; set; }
        [XmlElement(ElementName = "sku")]
        public string Sku { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "lines")]
    public class Lines
    {
        [XmlElement(ElementName = "line")]
        public List<Line> Line { get; set; }
    }

    [XmlRoot(ElementName = "report")]
    public class PurchaseOrderReport
    {
        [XmlElement(ElementName = "lines")]
        public Lines Lines { get; set; }
    }

    public class PurchaseOrderRootReport
    {
        public PurchaseOrderRootReport()
        {
            PurchaseOrderReport = null;
        }

        public string ValidatorError { get; set; }
        public PurchaseOrderReport PurchaseOrderReport { get; set; }
    }
}
