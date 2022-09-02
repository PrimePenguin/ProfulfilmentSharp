using System.Collections.Generic;
using System.Text;

namespace ProfulfilmentSharp.Entities.Requests
{
    public static class ProfulfilmentEntityRequest
    {
        public static string GenerateProductPayload(ProfulfilmentProduct product) =>
            $@"
                <imports>
                    <import type='product' operation='{product.Operation}' externalReference='{product.ExternalReference}'> 
                        externalReference={product.ExternalReference}
                        description={product.Description}
                        weight={product.Weight}
                        weightUnits={product.WeightUnits} 
                        type={product.Type} 
                        quantityOnOrder={product.QuantityOnOrder}
                        priceNet={product.PriceNet}
                        priceGross={product.PriceGross} 
                        tax={product.Tax} 
                        taxCode={product.TaxCode}
                        currency={product.Currency} 
                        currencyUnits={product.CurrencyUnits} 
                        costNet={product.CostNet}
                        costGross={product.CostGross}
                        costTax={product.CostTax} 
                        costTaxCode={product.CostTaxCode}
                        costCurrency={product.CostCurrency} 
                        costCurrencyUnits={product.CostCurrencyUnits}
                        userDefined1={product.UserDefined1} 
                        userDefined2={product.UserDefined2} 
                        userDefined3={product.UserDefined3} 
                        userDefined4={product.UserDefined4} 
                        userDefined5={product.UserDefined5}  
                        activated={product.Activated} 
                        barcode={product.Barcode}
                    </import> 
                </imports>
             ";

        public static string GenerateOrderPayload(ImportOrderRequest request, string channel)
        {
            var payload = $@"
                <imports>
                   <import type='{request.Type}' operation='{request.Operation}' externalReference='{request.ExternalReference}'>
                    state=created
                    validated=true
                    customerComment={request.CustomerComment}
                    totalPriceNet={request.TotalPriceNet}
                    totalPriceGross={request.TotalPriceGross}
                    totalTax={request.TotalTax}
                    shippingPriceNet={request.ShippingPriceNet}
                    shippingPriceGross={request.ShippingPriceGross}
                    shippingTax={request.ShippingTax}
                    currency={request.Currency}
                    currencyUnits={request.CurrencyUnits}
                    placed={request.Placed}
                    authorised={request.Placed}
                    channel={channel}
                    userDefined1={request.UserDefined1}
                    userDefined2={request.UserDefined2}
                    userDefined3={request.UserDefined3}
                    userDefined4={request.UserDefined4}
                    userDefined5={request.UserDefined5}                    shipment.deliverySuggestionCode={request.UserDefined1}                    shipment.orderItem=entity:order                    {GetDeliveryDetails(request.Delivery)}{GetOrderLineItems(request.LineItems)}
                    </import> 
                </imports>
             ";

            return payload.Replace("&", "&amp;");
        }

        public static string GetOrderLineItems(IEnumerable<ImportOrderLineItem> lineItems)
        {
            var sb = new StringBuilder();
            var index = 1;
            var initial = $"orderLine.{index}.";
            foreach (var lineItem in lineItems)
            {
                var item = $@"
                    {initial}product.externalReference={lineItem.ProductExternalReference}
                    {initial}quantity={lineItem.Quantity}
                    {initial}totalPriceNet={lineItem.TotalPriceNet}
                    {initial}totalPriceGross={lineItem.TotalPriceGross}
                    {initial}state=created
                    {initial}totalPriceGross={lineItem.TotalPriceGross}
                    {initial}userDefined1={lineItem.UserDefined1}
                    {initial}userDefined2={lineItem.UserDefined2}
                    {initial}userDefined3={lineItem.UserDefined3}
                    {initial}userDefined4={lineItem.UserDefined4}
                    {initial}userDefined5={lineItem.UserDefined5}                                    {initial}shipment=entity:shipment
                    orderAttribute.{index}.name={lineItem.AttributeName}
                    orderAttribute.{index}.title={lineItem.AttributeTitle}
                    orderAttribute.{index}.value={lineItem.AttributeValue}
                    orderAttribute.{index}.orderItem=entity:order";
                sb.Append(item);
                index++;
            }
            return sb.ToString();
        }

        public static string GetDeliveryDetails(ImportOrderDelivery delivery) =>
            $@"
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
                deliveryMobilePhoneNumber={delivery.MobilePhoneNumber}
                deliveryCompanyName={delivery.CompanyName}
            ";

        public static string GetInvoiceDetails(ImportOrderInvoice invoice) =>
            $@"
                invoiceAddressLine1={invoice.AddressLine1}
                invoiceAddressLine2={invoice.AddressLine2}
                invoiceAddressLine3={invoice.AddressLine3}                invoiceAddressLine4={invoice.AddressLine4}
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
                invoiceCompanyName={invoice.CompanyName}
            ";

        public static string SupplierPurchaseOrder(PurchaseOrderRequest request) =>
            $@"
               <imports>
                <import type='purchaseOrder' operation='{request.Operation}'
                    externalReference = '{request.ExternalReference}'>
                    purchaseOrder.supplierReference = {request.SupplierReference}
                    purchaseOrder.supplier = {request.Supplier}
                    purchaseOrder.expectedDeliveryDate = {request.ExpectedDeliveryDate}
                    {SupplierOrderProducts(request.PurchaseOrderProducts)}
                </import>
              </imports>
            ";

        public static string SupplierOrderProducts(IEnumerable<PurchaseOrderProduct> products)
        {
            var sb = new StringBuilder();
            var itemCount = 1;
            foreach (var product in products)
            {
                var item = $@"
                    purchaseOrderLine.{itemCount}.product = {product.Product}
                    purchaseOrderLine.{itemCount}.quantity = {product.Quantity}
                    purchaseOrderLine.{itemCount}.purchaseOrder = {product.PurchaseOrder}
                    purchaseOrderLine.{itemCount}.externalReference = {product.ProductExternalReference}";
                sb.Append(item);
                itemCount++;
            }
            return sb.ToString();
        }

        public static string Return(ReturnImportRequest request) =>
            $@"
               <imports>
                    <import type='return' operation='{request.Operation}'>
                    return.orderReference = {request.OrderReference}
                    return.authorisation = {request.Authorisation}
                    return.authorised = {request.Authorised}
                    return.type = {request.ReturnType}
                    return.storeId = {request.StoreId}
                    return.returnDate = {request.ReturnDate}
                    return.user = {request.User}
                    return.organisation = {request.Organisation}
                    return.site = {request.Site}
                    return.note ={request.Note}{ReturnLineItems(request.ReturnLineItems)}
                </import>
              </imports>
            ";

        public static string ReturnLineItems(List<ReturnLineItem> lineItems)
        {
            var sb = new StringBuilder();
            var itemCount = 1;
            foreach (var lineItem in lineItems)
            {
                var item = $@"
                    returnLine.{itemCount}.quantity = {lineItem.Quantity}
                    returnLine.{itemCount}.reason = {lineItem.Reason}
                    returnLine.{itemCount}.condition = {lineItem.Condition}
                    returnLine.{itemCount}.product = {lineItem.Product}
                    returnLine.{itemCount}.returnItem ={lineItem.ReturnItem}";
                sb.Append(item);
                itemCount++;
            }
            return sb.ToString();
        }

        public static string Campaign(CampaignImport request) =>
            $@"
              <imports>
                <import type='campaign' operation='insert' externalReference='campaign_reference'>
                    externalReference = campaign_reference
                    name = {request.Name}
                    description = {request.Description}
                    channel = {request.Channel}
                    startDate = {request.StartDate}
                    breakDate = {request.BreakDate}
                    endDate = {request.EndDate}
                    state = {request.State}{CampaignLineItems(request.CampaignLineItems)}
                </import>
             </imports> 
            ";

        public static string CampaignLineItems(List<CampaignLineItem> lineItems)
        {
            var sb = new StringBuilder();
            var itemCount = 1;
            foreach (var lineItem in lineItems)
            {
                var item = $@"
                    campaignLine.{itemCount}.quantity = {lineItem.Quantity}
                    campaignLine.{itemCount}.product.externalReference = {lineItem.ProductExternalReference}
                    campaignLine.{itemCount}.campaign = {lineItem.Campaign}";
                sb.Append(item);
                itemCount++;
            }
            return sb.ToString();
        }
    }
}