using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "import")]
    public class ReturnImportRequest
    {
        /// <summary>
        ///  The type of the return (e.g. ‘goods_not_delivered’, ‘goods_damaged’, ‘unknown’). Note that this is configurable.
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string AttributeType { get; set; }

        [XmlAttribute(AttributeName = "operation")]
        public string AttributeOperation { get; set; }

        /// <summary>
        /// The order number that this Return refers to
        /// </summary>
        [Required]
        [XmlElement(ElementName = "return.orderReference")]
        public string OrderReference { get; set; }

        /// <summary>
        /// Either the authorisation reference or order number (depending on OrderFlow configuration). Must have a value if no orderReference is specified
        /// </summary>
        [XmlElement(ElementName = "return.authorisation")]
        public string Authorisation { get; set; }

        /// <summary>
        /// Whether the return is authorised
        /// </summary>
        [XmlElement(ElementName = "return.authorised")]
        public string Authorised { get; set; }

        [XmlElement(ElementName = "return.type")]
        public string ReturnType { get; set; }

        /// <summary>
        /// The ID of the store from which the return is being made
        /// </summary>
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

        /// <summary>
        /// Note to be added to return.
        /// </summary>
        [XmlElement(ElementName = "return.note")]
        public string Note { get; set; }

        [XmlElement(ElementName = "return.lineItems")]
        public List<ReturnLineItem> ReturnLineItems { get; set; }
    }

    public class ReturnLineItem
    {
        [XmlElement(ElementName = "returnLine.1.quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Reason for the return, for example one of: [A - Not wanted, B - Not as described, C - Wrong size, D - Wrong product sent, E - Quality/Manufacturing fault, F - Damaged in transit, G - Late arrival, H - Other]. Note that this is configurable
        /// </summary>
        [XmlElement(ElementName = "returnLine.1.reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Condition of the item(s) being returned, for example one of: [As new, Packaging damaged, Product damaged(refurbishable), Product damaged(irreparable)]. Note that this is configurable.
        /// </summary>
        [XmlElement(ElementName = "returnLine.1.condition")]
        public string Condition { get; set; }

        [XmlElement(ElementName = "returnLine.1.product")]
        public string Product { get; set; }

        [XmlElement(ElementName = "returnLine.1.returnItem")]
        public string ReturnItem { get; set; }
    }
}