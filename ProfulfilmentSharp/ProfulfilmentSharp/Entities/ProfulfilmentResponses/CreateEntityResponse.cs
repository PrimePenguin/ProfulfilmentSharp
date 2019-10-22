using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.ProfulfilmentResponses
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

    public class CreateOrUpdateEntityRootResponse
    {
        public CreateOrUpdateEntityRootResponse()
        {
            CreateOrUpdateEntityResponse = null;
        }
        public string ValidationError { get; set; }
        public CreateOrUpdateEntityResponse CreateOrUpdateEntityResponse { get; set; }
    }
}