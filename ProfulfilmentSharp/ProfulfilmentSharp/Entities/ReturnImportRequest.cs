using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "import")]
    public class ReturnImportRequest
    {
        /// <summary>
        /// return
        /// </summary>
        [XmlAttribute(AttributeName = "type")] public string AttributeType { get; set; }

        [XmlAttribute(AttributeName = "operation")]
        public string AttributeOperation { get; set; }

        [XmlElement(ElementName = "return.orderReference")]
        public string OrderReference { get; set; }

        [XmlElement(ElementName = "return.authorisation")]
        public string Authorisation { get; set; }

        [XmlElement(ElementName = "return.authorised")]
        public string Authorised { get; set; }

        [XmlElement(ElementName = "return.type")]
        public string ReturnType { get; set; }

        [XmlElement(ElementName = "return.storeId")]
        public string StoreId { get; set; }

        [XmlElement(ElementName = "return.returnDate")]
        public string ReturnDate { get; set; }

        [XmlElement(ElementName = "return.user")]
        public string User { get; set; }

        [XmlElement(ElementName = "return.organisation")]
        public string Organisation { get; set; }

        [XmlElement(ElementName = "return.site")]
        public string Site { get; set; }

        [XmlElement(ElementName = "return.note")]
        public string Note { get; set; }

        [XmlElement(ElementName = "return.lineItems")]
        public List<ReturnLineItem> ReturnLineItems { get; set; }
    }

    public class ReturnLineItem
    {
        [XmlElement(ElementName = "returnLine.1.quantity")]
        public string Quantity { get; set; }

        [XmlElement(ElementName = "returnLine.1.reason")]
        public string Reason { get; set; }

        [XmlElement(ElementName = "returnLine.1.condition")]
        public string Condition { get; set; }

        [XmlElement(ElementName = "returnLine.1.product")]
        public string Product { get; set; }

        [XmlElement(ElementName = "returnLine.1.returnItem")]
        public string ReturnItem { get; set; }
    }
}