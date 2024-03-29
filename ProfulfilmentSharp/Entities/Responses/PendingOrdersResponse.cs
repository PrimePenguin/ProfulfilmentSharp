﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Responses
{
    [XmlRoot(ElementName = "shipments")]
    public class PendingOrdersResponse
    {
        [XmlElement(ElementName = "shipment")]
        public List<Shipment> Shipments { get; set; }
    }

    public class Shipment
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
}