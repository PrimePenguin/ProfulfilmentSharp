using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ProfulfilmentSharp.Entities;

namespace ProfulfilmentSharp.Services.Order
{
    public class OrderService : ProfulfilmentService
    {
        public OrderService(string userName, string password) : base(userName, password)
        {
        }

        public virtual Entities.Order GetOrderByExternalReference(string channel, string externalReference)
        {
            var requestUrl = PrepareRequestUrl($"test/remoteorder/order/detail.xml?channel={channel}" +
                                               $"&externalReference={externalReference}");
            return ExecuteGetRequest<Entities.Order>(requestUrl, HttpMethod.Get);
        }

        public virtual DispatchedShipments GetDispatchedShipmentByDate(string channel, string from, string to)
        {
            var requestUrl =
                PrepareRequestUrl($"test/remoteorder/shipment/despatches.xml?channel={channel}&from={from}&to={to}");
            return ExecuteGetRequest<DispatchedShipments>(requestUrl, HttpMethod.Get);
        }

        public virtual CreateEntityResponse CreateNewOrder(ImportOrderRequest request)
        {
            var result = ExecutePostRequest<CreateEntityResponse>(new RequestContent
            {
                RequestUri = PrepareRequestUrl($"test/remoteorder/imports/importitems.xml"),
                Content = GetOder(request),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> {{"channel", "channel1"}}
            });
            return result;
        }

        #region Private Methods

        private static string GetOder(ImportOrderRequest request)
        {
            var delivery = request.Delivery;
            var invoice = request.Invoice;
            var shipment = request.Shipment;

            return $@"
                <imports>
                   <import type='order' operation='insert' externalReference='{request.ExternalReference}'>
                    state={request.State}
                    validated={request.Validated}
                    paymentTransactionInfo={request.PaymentTransactionInfo}
                    customerComment={request.CustomerComment}
                    totalPriceNet={request.TotalPriceNet}
                    totalPriceGross={request.TotalPriceGross}
                    totalTax={request.TotalTax}
                    totalTaxCode={request.TotalTaxCode}
                    shippingPriceNet={request.ShippingPriceNet}
                    shippingPriceGross={request.ShippingPriceGross}
                    shippingTax={request.ShippingTax}
                    shippingTaxCode={request.ShippingTaxCode}
                    currency={request.Currency}
                    currencyUnits={request.CurrencyUnits}
                    placed={request.Placed}
                    authorised={request.Authorised}
                    source={request.Source}
                    userDefined1={request.UserDefined1}
                    userDefined2={request.UserDefined2}
                    userDefined3={request.UserDefined3}
                    userDefined4={request.UserDefined4}
                    userDefined5={request.UserDefined5}{GetDeliveryDetails(delivery)}{GetInvoiceDetails(invoice)}                    {GetShipmentDetails(shipment)}{GetOrderLineItems(request.LineItems)}
                    </import> 
                </imports>
                ";
        }

        private static string GetOrderLineItems(IEnumerable<ImportOrderLineItem> lineItems)
        {
            var sb = new StringBuilder();
            foreach (var lineItem in lineItems)
            {
                var item =
                    $@"
                    <orderLine.1.product.externalReference>{lineItem.ProductExternalReference}</orderLine.1.product.externalReference>
                    <orderLine.1.quantity>{lineItem.Quantity}</orderLine.1.quantity>
                    <orderLine.1.state>{lineItem.State}</orderLine.1.state>
                    <orderLine.1.totalPriceNet>{lineItem.TotalPriceNet} </orderLine.1.totalPriceNet>
                    <orderLine.1.totalPriceGross>{lineItem.TotalPriceGross}</orderLine.1.totalPriceGross>
                    <orderLine.1.totalTax>{lineItem.TotalTax}</orderLine.1.totalTax>
                    <orderLine.1.totalTaxCode>{lineItem.TotalTaxCode}</orderLine.1.totalTaxCode>                    <orderLine.1.unitPriceNet>{lineItem.UnitPriceNet}</orderLine.1.unitPriceNet>
                    <orderLine.1.unitPriceGross>{lineItem.UnitPriceGross}</orderLine.1.unitPriceGross>
                    <orderLine.1.unitTax>{lineItem.UnitTax}</orderLine.1.unitTax>
                    <orderLine.1.unitTaxCode>{lineItem.UnitTaxCode}</orderLine.1.unitTaxCode>
                    <orderLine.1.userDefined1>{lineItem.UserDefined1}</orderLine.1.userDefined1>
                    <orderLine.1.userDefined2>{lineItem.UserDefined2}</orderLine.1.userDefined2>
                    <orderLine.1.userDefined3>{lineItem.UserDefined3}</orderLine.1.userDefined3>
                    <orderLine.1.userDefined4>{lineItem.UserDefined4}</orderLine.1.userDefined4>
                    <orderLine.1.userDefined5>{lineItem.UserDefined5}</orderLine.1.userDefined5>                                     <orderLine.1.shipment>{lineItem.Shipment}</orderLine.1.shipment>
                    <orderAttribute.1.name>{lineItem.AttributeName}</orderAttribute.1.name>
                    <orderAttribute.1.title>{lineItem.AttributeTitle}</orderAttribute.1.title>
                    <orderAttribute.1.value>{lineItem.AttributeValue}</orderAttribute.1.value>
                    <orderAttribute.1.orderItem>{lineItem.OrderItem}</orderAttribute.1.orderItem>";
                sb.Append(item);
            }
            return sb.ToString();
        }

        private static string GetDeliveryDetails(ImportOrderDelivery delivery)
        {
            return $@"
                    deliveryAddressLine1={delivery.AddressLine1}
                    deliveryAddressLine2={delivery.AddressLine2}
                    deliveryAddressLine3={delivery.AddressLine3}
                    deliveryAddressLine4={delivery.AddressLine4}
                    deliveryAddressLine5={delivery.AddressLine5}
                    deliveryAddressLine6={delivery.AddressLine6}
                    deliveryCountryCode={delivery.CountryCode}
                    deliveryPostCode={delivery.PostCode}
                    deliveryContactName={delivery.ContactName}
                    deliveryEmailAddress={delivery.EmailAddress}
                    deliveryDayPhoneNumber={delivery.DayPhoneNumber}
                    deliveryEveningPhoneNumber={delivery.EveningPhoneNumber}
                    deliveryMobilePhoneNumber={delivery.MobilePhoneNumber}
                    deliveryFaxNumber={delivery.FaxNumber}
                    deliveryCompanyName={delivery.CompanyName}";
        }

        private static string GetInvoiceDetails(ImportOrderInvoice invoice)
        {
            return $@"
                    invoiceAddressLine1={invoice.AddressLine1}
                    invoiceAddressLine2={invoice.AddressLine2}
                    invoiceAddressLine3={invoice.AddressLine3}                    invoiceAddressLine4={invoice.AddressLine4}
                    invoiceAddressLine5={invoice.AddressLine5}
                    invoiceAddressLine6={invoice.AddressLine6}
                    invoiceCountryCode={invoice.CountryCode}
                    invoicePostCode={invoice.PostCode}
                    invoiceContactName={invoice.ContactName}
                    invoiceEmailAddress={invoice.EmailAddress}
                    invoiceDayPhoneNumber={invoice.DayPhoneNumber}
                    invoiceEveningPhoneNumber={invoice.EveningPhoneNumber}>
                    invoiceMobilePhoneNumber={invoice.MobilePhoneNumber}
                    invoiceFaxNumber={invoice.FaxNumber}
                    invoiceCompanyName={invoice.CompanyName}";
        }

        private static string GetShipmentDetails(ImportOrderShipment shipment)
        {
            return $@"
                    shipment.externalReference={shipment.ProductExternalReference}
                    shipment.state={shipment.State}
                    shipment.earliestShipDate={shipment.EarliestShipDate}
                    shipment.deliveryInstruction={shipment.DeliveryInstruction}
                    shipment.despatchComment={shipment.DespatchComment}
                    shipment.despatchReference={shipment.DespatchReference}
                    shipment.weight={shipment.Weight}
                    shipment.weightUnits={shipment.WeightUnits}
                    shipment.itemCount={shipment.ItemCount}
                    shipment.addressLine1={shipment.AddressLine1}
                    shipment.addressLine2={shipment.AddressLine2}
                    shipment.addressLine3={shipment.AddressLine3}
                    shipment.addressLine4={shipment.AddressLine4}
                    shipment.addressLine5={shipment.AddressLine5}
                    shipment.addressLine6={shipment.AddressLine6}
                    shipment.countryCode={shipment.CountryCode}
                    shipment.postCode={shipment.PostCode}
                    shipment.contactName={shipment.ContactName}
                    shipment.emailAddress={shipment.EmailAddress}
                    shipment.dayPhoneNumber={shipment.DayPhoneNumber}
                    shipment.eveningPhoneNumber={shipment.EveningPhoneNumber}
                    shipment.mobilePhoneNumber={shipment.MobilePhoneNumber}
                    shipment.faxNumber={shipment.FaxNumber}
                    shipment.companyName={shipment.CompanyName}
                    shipment.userDefined1={shipment.UserDefined1}
                    shipment.userDefined2={shipment.UserDefined2}
                    shipment.userDefined3={shipment.UserDefined3}
                    shipment.userDefined4={shipment.UserDefined4}
                    shipment.userDefined5={shipment.UserDefined5}
                    shipment.deliverySuggestionCode={shipment.DeliverySuggestionCode}
                    shipment.deliverySuggestionName={shipment.DeliverySuggestionName}
                    shipment.orderItem={shipment.OrderItem}";
        }

        #endregion
    }
}