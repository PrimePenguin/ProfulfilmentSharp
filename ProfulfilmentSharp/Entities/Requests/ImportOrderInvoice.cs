using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class ImportOrderInvoice
    {
        [XmlElement(ElementName = "invoiceAddressLine1")]
        public string AddressLine1 { get; set; }

        [XmlElement(ElementName = "invoiceAddressLine2")]
        public string AddressLine2 { get; set; }

        [XmlElement(ElementName = "invoiceAddressLine3")]
        public string AddressLine3 { get; set; }

        [XmlElement(ElementName = "invoiceAddressLine4")]
        public string AddressLine4 { get; set; }

        [XmlElement(ElementName = "invoiceAddressLine5")]
        public string AddressLine5 { get; set; }

        [XmlElement(ElementName = "invoiceAddressLine6")]
        public string AddressLine6 { get; set; }

        [XmlElement(ElementName = "invoiceCountryCode")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "invoicePostCode")]
        public string PostCode { get; set; }

        [XmlElement(ElementName = "invoiceContactName")]
        public string ContactName { get; set; }

        [XmlElement(ElementName = "invoiceEmailAddress")]
        public string EmailAddress { get; set; }

        [XmlElement(ElementName = "invoiceDayPhoneNumber")]
        public string DayPhoneNumber { get; set; }

        [XmlElement(ElementName = "invoiceEveningPhoneNumber")]
        public string EveningPhoneNumber { get; set; }

        [XmlElement(ElementName = "invoiceMobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }

        [XmlElement(ElementName = "invoiceFaxNumber")]
        public string FaxNumber { get; set; }

        [XmlElement(ElementName = "invoiceCompanyName")]
        public string CompanyName { get; set; }
    }
}