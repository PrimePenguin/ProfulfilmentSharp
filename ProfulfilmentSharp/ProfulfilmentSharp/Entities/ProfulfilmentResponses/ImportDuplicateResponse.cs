using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.ProfulfilmentResponses
{
    [XmlRoot(ElementName = "import")]
    public class ImportDuplicateResponse
    {
        [XmlElement(ElementName = "duplicateMessage")]
        public string DuplicateMessage { get; set; }
        [XmlElement(ElementName = "duplicateDetail")]
        public string DuplicateDetail { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "queryTime")]
        public string QueryTime { get; set; }
    }

    [XmlRoot(ElementName = "importDuplicates")]
    public class ImportDuplicates
    {
        [XmlElement(ElementName = "import")]
        public List<ImportDuplicateResponse> ImportDuplicateResponses { get; set; }
    }
}