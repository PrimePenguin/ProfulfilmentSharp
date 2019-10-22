using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.ProfulfilmentRequests
{
    [XmlRoot(ElementName = "shipments")]
    public class DispatchedShipments
    {
        [XmlElement(ElementName = "shipment")]
        public List<DispatchedShipment> Shipment { get; set; }
    }

    public class RootDispatchedShipments
    {
        public RootDispatchedShipments()
        {
            DispatchedShipments = null;
        }
        public string ValidationError { get; set; }
        public DispatchedShipments DispatchedShipments { get; set; }
    }
}