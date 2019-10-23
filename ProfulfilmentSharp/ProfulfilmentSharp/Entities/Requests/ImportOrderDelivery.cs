using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class ImportOrderDelivery
    {
        [XmlElement(ElementName = "deliveryAddressLine1")]
        public string AddressLine1 { get; set; }

        [XmlElement(ElementName = "deliveryAddressLine2")]
        public string AddressLine2 { get; set; }

        [XmlElement(ElementName = "deliveryAddressLine3")]
        public string AddressLine3 { get; set; }

        [XmlElement(ElementName = "deliveryAddressLine4")]
        public string AddressLine4 { get; set; }

        [XmlElement(ElementName = "deliveryAddressLine5")]
        public string AddressLine5 { get; set; }

        [XmlElement(ElementName = "deliveryAddressLine6")]
        public string AddressLine6 { get; set; }

        [XmlElement(ElementName = "deliveryCountryCode")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "deliveryPostCode")]
        public string PostCode { get; set; }

        [XmlElement(ElementName = "deliveryContactName")]
        public string ContactName { get; set; }

        [XmlElement(ElementName = "deliveryEmailAddress")]
        public string EmailAddress { get; set; }

        [XmlElement(ElementName = "deliveryDayPhoneNumber")]
        public string DayPhoneNumber { get; set; }

        [XmlElement(ElementName = "deliveryEveningPhoneNumber")]
        public string EveningPhoneNumber { get; set; }

        [XmlElement(ElementName = "deliveryMobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }

        [XmlElement(ElementName = "deliveryFaxNumber")]
        public string FaxNumber { get; set; }

        [XmlElement(ElementName = "deliveryCompanyName")]
        public string CompanyName { get; set; }
    }
}