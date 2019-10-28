using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
{
    [XmlRoot(ElementName = "import")]
    public class CampaignImport
    {
        [XmlElement(ElementName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string _ExternalReference { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "description")]
        public string Campaign { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        public string Description { get; set; }
        [XmlElement(ElementName = "channel")]
        public string Channel { get; set; }

        /// <summary>
        /// The ‘scheduled’ start date of the campaign, when it effectively becomes active.
        /// </summary>
        [XmlElement(ElementName = "startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// The ‘scheduled’ date by which the primary activity on the campaign needs to be completed. SLAs can be measured against this date.
        /// </summary>
        [XmlElement(ElementName = "breakDate")]
        public string BreakDate { get; set; }

        /// <summary>
        /// The date at which the campaign needs to be terminated.
        /// </summary>
        [XmlElement(ElementName = "endDate")]
        public string EndDate { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }

        [XmlElement(ElementName = "campaignLineItems")]
        public List<CampaignLineItem> CampaignLineItems { get; set; }
    }

    public class CampaignLineItem
    {
        public string Quantity { get; set; }
        public string ProductExternalReference { get; set; }
        public string Campaign { get; set; }
    }
}