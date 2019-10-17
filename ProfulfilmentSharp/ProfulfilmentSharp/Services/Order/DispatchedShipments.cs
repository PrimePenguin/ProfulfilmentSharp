using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "shipments")]
    public class DispatchedShipments
    {
        [XmlElement(ElementName = "shipment")]
        public List<DispatchedShipment> Shipment { get; set; }
    }
}