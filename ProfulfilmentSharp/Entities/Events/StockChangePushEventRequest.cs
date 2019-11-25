using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Events
{
    [XmlRoot(ElementName = "stockChange")]
    public class StockChange
    {
        [XmlElement(ElementName = "note")] 
        public string Note { get; set; }
        [XmlAttribute(AttributeName = "id")] 
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")] 
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }

        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }

        [XmlAttribute(AttributeName = "location")]
        public string Location { get; set; }

        [XmlAttribute(AttributeName = "locationType")]
        public string LocationType { get; set; }

        [XmlAttribute(AttributeName = "previousQuantity")]
        public string PreviousQuantity { get; set; }

        [XmlAttribute(AttributeName = "changeQuantity")]
        public string ChangeQuantity { get; set; }

        [XmlAttribute(AttributeName = "newQuantity")]
        public string NewQuantity { get; set; }

        [XmlAttribute(AttributeName = "user")] public string User { get; set; }
    }

    [XmlRoot(ElementName = "stockChanges")]
    public class StockChangePushEventRequest
    {
        [XmlElement(ElementName = "stockChange")]
        public StockChange StockChange { get; set; }

        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }

        [XmlAttribute(AttributeName = "organisation")]
        public string Organisation { get; set; }

        [XmlAttribute(AttributeName = "site")] 
        public string Site { get; set; }
    }
}