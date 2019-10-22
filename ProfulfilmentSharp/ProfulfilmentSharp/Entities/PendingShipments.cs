using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "shipment")]
    public class PendingShipment
    {
        [XmlElement(ElementName = "created")]
        public string Created { get; set; }
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "orderReference")]
        public string OrderReference { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }
        [XmlElement(ElementName = "earliestShipDate")]
        public string EarliestShipDate { get; set; }
    }

    [XmlRoot(ElementName = "shipments")]
    public class PendingShipments
    {
        [XmlElement(ElementName = "shipment")]
        public List<PendingShipment> Shipments { get; set; }
    }

    public class PendingShipmentRootRequest
    {
        public PendingShipmentRootRequest()
        {
            PendingShipments = null;
        }
        public string ValidationError { get; set; }
        public PendingShipments PendingShipments { get; set; }
    }
}