using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Events
{
    [XmlRoot(ElementName = "returnLine")]
    public class ReturnLine
    {
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "reason")]
        public string Reason { get; set; }
        [XmlAttribute(AttributeName = "condition")]
        public string Condition { get; set; }
        [XmlAttribute(AttributeName = "refund")]
        public string Refund { get; set; }
    }

    [XmlRoot(ElementName = "return")]
    public class Return
    {
        [XmlElement(ElementName = "returnLine")]
        public List<ReturnLine> ReturnLine { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "authorised")]
        public string Authorised { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "site")]
        public string Site { get; set; }
        [XmlAttribute(AttributeName = "authorisation")]
        public string Authorisation { get; set; }
        [XmlAttribute(AttributeName = "orderReference")]
        public string OrderReference { get; set; }
    }

    [XmlRoot(ElementName = "detail")]
    public class PushReturnDetail
    {
        [XmlElement(ElementName = "return")]
        public Return Return { get; set; }
    }

    [XmlRoot(ElementName = "event")]
    public class PushReturnEvent
    {
        [XmlElement(ElementName = "detail")]
        public PushReturnDetail Detail { get; set; }
        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }
        [XmlAttribute(AttributeName = "eventType")]
        public string EventType { get; set; }
        [XmlAttribute(AttributeName = "userName")]
        public string UserName { get; set; }
        [XmlAttribute(AttributeName = "eventTime")]
        public string EventTime { get; set; }
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }
    }
}