using System.Collections.Generic;
using System.Text;

namespace ProfulfilmentSharp.Entities.Requests
{
    public static class ProfulfilmentEntityRequestBody
    {
        public static string Product(Import product)
        {
            return $@"
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
                        colour={product.Colour}
                    </import> 
                </imports>
                ";
        }

        public static string Order(ImportOrderRequest request)
        {
            var delivery = request.Delivery;
            var shipment = request.Shipment;

            return $@"
                <imports>
                   <import type='order' operation='{request.Operation}' externalReference='{request.ExternalReference}'>
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
                    authorised={request.Authorised}
                    userDefined1={request.UserDefined1}
                    userDefined2={request.UserDefined2}
                    userDefined3={request.UserDefined3}
                    userDefined4={request.UserDefined4}
                    userDefined5={request.UserDefined5}                    {GetDeliveryDetails(delivery)}{GetShipmentDetails(shipment)}{GetOrderLineItems(request.LineItems)}
                    </import> 
                </imports>
                ";
        }

        public static string GetOrderLineItems(IEnumerable<ImportOrderLineItem> lineItems)
        {
            var sb = new StringBuilder();
            var itemCount = 1;
            foreach (var lineItem in lineItems)
            {
                var item = $@"
                    orderLine.{itemCount}.product.externalReference={lineItem.ProductExternalReference}
                    orderLine.{itemCount}.quantity={lineItem.Quantity}
                    orderLine.{itemCount}.totalPriceNet={lineItem.TotalPriceNet}
                    orderLine.{itemCount}.totalPriceGross={lineItem.TotalPriceGross}
                    orderLine.{itemCount}.userDefined1={lineItem.UserDefined1}
                    orderLine.{itemCount}.userDefined2={lineItem.UserDefined2}
                    orderLine.{itemCount}.userDefined3={lineItem.UserDefined3}
                    orderLine.{itemCount}.userDefined4={lineItem.UserDefined4}
                    orderLine.{itemCount}.userDefined5={lineItem.UserDefined5}                                    orderLine.{itemCount}.shipment={lineItem.Shipment}
                    orderAttribute.{itemCount}.name={lineItem.AttributeName}
                    orderAttribute.{itemCount}.title={lineItem.AttributeTitle}
                    orderAttribute.{itemCount}.value={lineItem.AttributeValue}
                    orderAttribute.{itemCount}.orderItem={lineItem.OrderItem}";
                sb.Append(item);
                itemCount++;
            }
            return sb.ToString();
        }

        public static string GetDeliveryDetails(ImportOrderDelivery delivery)
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
                    deliveryMobilePhoneNumber={delivery.MobilePhoneNumber}
                    deliveryCompanyName={delivery.CompanyName}";
        }

        public static string GetInvoiceDetails(ImportOrderInvoice invoice)
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

        public static string GetShipmentDetails(ImportOrderShipment shipment)
        {
            return $@"
                    shipment.externalReference={shipment.ProductExternalReference}
                    shipment.state={shipment.State}
                    shipment.earliestShipDate={shipment.EarliestShipDate}
                    shipment.deliveryInstruction={shipment.DeliveryInstruction}
                    shipment.despatchComment={shipment.DespatchComment}
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
                    shipment.contactName={shipment.ContactName}
                    shipment.emailAddress={shipment.EmailAddress}
                    shipment.dayPhoneNumber={shipment.DayPhoneNumber}
                    shipment.mobilePhoneNumber={shipment.MobilePhoneNumber}
                    shipment.companyName={shipment.CompanycourierName}
                    shipment.userDefined1={shipment.UserDefined1}
                    shipment.userDefined2={shipment.UserDefined2}
                    shipment.userDefined3={shipment.UserDefined3}
                    shipment.userDefined4={shipment.UserDefined4}
                    shipment.userDefined5={shipment.UserDefined5}
                    shipment.deliverySuggestionCode={shipment.DeliverySuggestionCode}
                    shipment.orderItem={shipment.OrderItem}";
        }

        public static string SupplierPurchaseOrder(PurchaseOrderRequest request)
        {
            return $@"
                   <imports>
                    <import type='purchaseOrder' operation='{request.Operation}'
                        externalReference = '{request.ExternalReference}'>
                        purchaseOrder.supplierReference = {request.SupplierReference}
                        purchaseOrder.supplier = {request.Supplier}
                        purchaseOrder.expectedDeliveryDate = {request.ExpectedDeliveryDate}
                        {SupplierOrderProducts(request.PurchaseOrderProducts)}
                    </import>
                  </imports>";
        }

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

        public static string Return(ReturnImportRequest request)
        {
            return $@"
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
             </imports>";
        }

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

        public static string Campaign(CampaignImport request)
        {
            return $@"
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
                </imports> ";
        }

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