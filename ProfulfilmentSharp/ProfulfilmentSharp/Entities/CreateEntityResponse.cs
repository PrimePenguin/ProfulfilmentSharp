using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "importResult")]
    public class CreateOrUpdateEntityResponse
    {
        [XmlElement(ElementName = "importSuccesses")]
        public ImportSuccesses ImportSuccesses { get; set; }

        [XmlElement(ElementName = "importFailures")]
        public ImportFailures ImportFailures { get; set; }
        [XmlElement(ElementName = "importDuplicates")]
        public ImportDuplicates ImportDuplicates { get; set; }
    }
}