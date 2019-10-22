using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.ProfulfilmentResponses
{
    [XmlRoot(ElementName = "import")]
    public class ImportFailureResponse
    {
        [XmlElement(ElementName = "failureMessage")]
        public string FailureMessage { get; set; }
        [XmlElement(ElementName = "failureDetail")]
        public string FailureDetail { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "queryTime")]
        public string QueryTime { get; set; }
    }

    [XmlRoot(ElementName = "importFailures")]
    public class ImportFailures
    {
        [XmlElement(ElementName = "import")]
        public ImportFailureResponse ImportFailureResponse { get; set; }
    }
}