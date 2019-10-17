using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Services.Order
{
    [XmlRoot(ElementName = "import")]
    public class Import
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "item")]
        public string Item { get; set; }
        [XmlAttribute(AttributeName = "queryTime")]
        public string QueryTime { get; set; }
    }

    [XmlRoot(ElementName = "importSuccesses")]
    public class ImportSuccesses
    {
        [XmlElement(ElementName = "import")]
        public List<Import> Import { get; set; }
    }

    [XmlRoot(ElementName = "importResult")]
    public class ImportOrderResponse
    {
        [XmlElement(ElementName = "importSuccesses")]
        public ImportSuccesses ImportSuccesses { get; set; }
        [XmlElement(ElementName = "importFailures")]
        public string ImportFailures { get; set; }
        [XmlElement(ElementName = "importDuplicates")]
        public string ImportDuplicates { get; set; }
    }
}
