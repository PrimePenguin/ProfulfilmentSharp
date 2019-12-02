using System.Collections.Generic;
using System.Security.Principal;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Responses
{
    [XmlRoot(ElementName = "line")]
    public class Line
    {
        [XmlElement(ElementName = "organisation")]
        public string Organisation { get; set; }
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }
        [XmlElement(ElementName = "supplier")]
        public string Supplier { get; set; }
        [XmlElement(ElementName = "supplierReference")]
        public string SupplierReference { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "created")]
        public string Created { get; set; }
        [XmlElement(ElementName = "lastUpdated")]
        public string LastUpdated { get; set; }
        [XmlElement(ElementName = "completed")]
        public string Completed { get; set; }
        [XmlElement(ElementName = "lineQuantity")]
        public string LineQuantity { get; set; }
        [XmlElement(ElementName = "lineOutstandingQuantity")]
        public string LineOutstandingQuantity { get; set; }
        [XmlElement(ElementName = "lineState")]
        public string LineState { get; set; }
        [XmlElement(ElementName = "sku")]
        public string Sku { get; set; }
        [XmlElement(ElementName = "productDescription")]
        public string ProductDescription { get; set; }
    }

    [XmlRoot(ElementName = "lines")]
    public class PurchaseOrders
    {
        [XmlElement(ElementName = "line")]
        public List<Line> Line { get; set; }
    }

    [XmlRoot(ElementName = "report")]
    public class PurchaseOrderReport  
    {
        [XmlElement(ElementName = "lines")]
        public PurchaseOrders PurchaseOrders { get; set; }
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
