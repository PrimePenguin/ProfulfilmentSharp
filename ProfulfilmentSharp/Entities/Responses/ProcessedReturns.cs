using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Responses
{
    [XmlRoot(ElementName = "returns")]
    public class ProcessedReturns
    {
        [XmlElement(ElementName = "return")]
        public List<ProcessedReturn> Returns { get; set; }
    }

    public class ProcessedReturn
    {
        [XmlElement(ElementName = "organisation")]
        public string Organisation { get; set; }

        [XmlElement(ElementName = "channel")]
        public string Channel { get; set; }

        [XmlElement(ElementName = "orderReference")]
        public string OrderReference { get; set; }

        [XmlElement(ElementName = "product")]
        public string Product { get; set; }

        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "returnedDate")]
        public string ReturnedDate { get; set; }

        [XmlElement(ElementName = "completedDate")]
        public string CompletedDate { get; set; }

        [XmlElement(ElementName = "authorised")]
        public string Authorised { get; set; }

        [XmlElement(ElementName = "authorisation")]
        public string Authorisation { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "note")]
        public string Note { get; set; }

        [XmlElement(ElementName = "lineReason")]
        public string LineReason { get; set; }

        [XmlElement(ElementName = "lineCondition")]
        public string LineCondition { get; set; }

        [XmlElement(ElementName = "lineType")]
        public string LineType { get; set; }

        [XmlElement(ElementName = "lineNote")]
        public string LineNote { get; set; }
    }
}
