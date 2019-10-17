using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    public class ImportOrderShipment
    {
        [XmlElement(ElementName = "shipment.externalReference")]
        public string ProductExternalReference { get; set; }

        [XmlElement(ElementName = "shipment.state")]
        public string State { get; set; }

        [XmlElement(ElementName = "shipment.earliestShipDate")]
        public string EarliestShipDate { get; set; }

        [XmlElement(ElementName = "shipment.deliveryInstruction")]
        public string DeliveryInstruction { get; set; }

        [XmlElement(ElementName = "shipment.despatchComment")]
        public string DespatchComment { get; set; }

        [XmlElement(ElementName = "shipment.despatchReference")]
        public string DespatchReference { get; set; }

        [XmlElement(ElementName = "shipment.weight")]
        public float Weight { get; set; }

        [XmlElement(ElementName = "shipment.weightUnits")]
        public string WeightUnits { get; set; }

        [XmlElement(ElementName = "shipment.itemCount")]
        public string ItemCount { get; set; }

        [XmlElement(ElementName = "shipment.addressLine1")]
        public string AddressLine1 { get; set; }

        [XmlElement(ElementName = "shipment.addressLine2")]
        public string AddressLine2 { get; set; }

        [XmlElement(ElementName = "shipment.addressLine3")]
        public string AddressLine3 { get; set; }

        [XmlElement(ElementName = "shipment.addressLine4")]
        public string AddressLine4 { get; set; }

        [XmlElement(ElementName = "shipment.addressLine5")]
        public string AddressLine5 { get; set; }

        [XmlElement(ElementName = "shipment.addressLine6")]
        public string AddressLine6 { get; set; }

        [XmlElement(ElementName = "shipment.countryCode")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "shipment.postCode")]
        public string PostCode { get; set; }

        [XmlElement(ElementName = "shipment.contactName")]
        public string ContactName { get; set; }

        [XmlElement(ElementName = "shipment.emailAddress")]
        public string EmailAddress { get; set; }

        [XmlElement(ElementName = "shipment.dayPhoneNumber")]
        public string DayPhoneNumber { get; set; }

        [XmlElement(ElementName = "shipment.eveningPhoneNumber")]
        public string EveningPhoneNumber { get; set; }

        [XmlElement(ElementName = "shipment.mobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }

        [XmlElement(ElementName = "shipment.faxNumber")]
        public string FaxNumber { get; set; }

        [XmlElement(ElementName = "shipment.companyName")]
        public string CompanyName { get; set; }

        [XmlElement(ElementName = "shipment.userDefined1")]
        public string UserDefined1 { get; set; }

        [XmlElement(ElementName = "shipment.userDefined2")]
        public string UserDefined2 { get; set; }

        [XmlElement(ElementName = "shipment.userDefined3")]
        public string UserDefined3 { get; set; }

        [XmlElement(ElementName = "shipment.userDefined4")]
        public string UserDefined4 { get; set; }

        [XmlElement(ElementName = "shipment.userDefined5")]
        public string UserDefined5 { get; set; }

        [XmlElement(ElementName = "shipment.deliverySuggestionCode")]
        public string DeliverySuggestionCode { get; set; }

        [XmlElement(ElementName = "shipment.deliverySuggestionName")]
        public string DeliverySuggestionName { get; set; }

        [XmlElement(ElementName = "shipment.orderItem")]
        public string OrderItem { get; set; }
    }
}