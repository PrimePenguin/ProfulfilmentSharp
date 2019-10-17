using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "import")]
    public class ImportSuccessResponse
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }
        [XmlAttribute(AttributeName = "item")]
        public string Item { get; set; }
        [XmlAttribute(AttributeName = "queryTime")]
        public string QueryTime { get; set; }
    }

    [XmlRoot(ElementName = "importSuccesses")]
    public class ImportSuccesses
    {
        [XmlElement(ElementName = "import")]
        public List<ImportSuccessResponse> ImportSuccessResponses { get; set; }
    }
}