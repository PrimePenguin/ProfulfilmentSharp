using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ProfulfilmentSharp.Entities;
using ProfulfilmentSharp.Entities.Requests;
using ProfulfilmentSharp.Entities.Responses;

namespace ProfulfilmentSharp.Services
{
    public class OrderService : ProfulfilmentService
    {
        public OrderService(string userName, string password) : base(userName, password)
        {
        }

        /// <summary>
        /// The order import defines a mechanism for importing orders supplied as an XML document.
        /// </summary>
        /// <param name="request">order data to be created</param>
        /// <param name="channel">Channel Name</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateOrder(ImportOrderRequest request, string channel)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }

            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(
                new ProfulfilmentRequestContent
                {
                    RequestUri = PrepareRequestUrl("remoteorder/imports/importitems.xml"),
                    PostData = ProfulfilmentEntityRequestBody.Order(request),
                    HttpMethod = HttpMethod.Post,
                    Headers = new Dictionary<string, string> { { "channel", channel } }
                });
            return response;
        }

        /// <summary>
        ///The OrderFlow API can be used to query the details on a particular order. This operation can be used to pick up all relevant information which    pertains to a single order at a particular point in time, including the current order and associated shipment states, the availability of individual line items, the earliest ship date, the despatch reference, etc.
        /// </summary>
        /// <param name="request">order by reference request</param>
        /// <returns></returns>
        public virtual OrderRootResponse GetOrder(OrderByReferenceRequest request)
        {
            var response = new OrderRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            var requestUrl = PrepareRequestUrl($"remoteorder/order/detail.xml?channel={request.Channel}&externalReference={request.ExternalReference}");
            var result = ExecuteGetRequest<Order>(requestUrl, HttpMethod.Get);
            response.Order = result;
            return response;
        }

        /// <summary>
        /// This operation allows third party systems to query dispatched shipments over a specified time period.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual RootDispatchedShipments GetDispatchedShipmentByTimeStamps(DispatchedShipmentRequest request)
        {
            var response = new RootDispatchedShipments();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            var requestUrl = PrepareRequestUrl($"remoteorder/shipment/despatches.xml?channel={request.Channel}&from={request.From}&to={request.To}");
            response.DispatchedShipments = ExecuteGetRequest<DispatchedShipments>(requestUrl, HttpMethod.Get);
            return response;
        }

        /// <summary>
        /// Import Supplier purchase order
        /// </summary>
        /// <param name="request"></param>
        /// <param name="organization">Organization Name</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateSupplierPurchaseOrder(SupplierPurchaseOrderImportRequest request, string organization)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(new ProfulfilmentRequestContent
            {
                RequestUri = PrepareRequestUrl("remotewarehouse/imports/importitems.xml"),
                PostData = ProfulfilmentEntityRequestBody.SupplierPurchaseOrder(request.PurchaseOrder),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "organisation", organization } }
            });
            return response;
        }

        /// <summary>
        /// The Return Item import defines a mechanism for importing customer returns remotely.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="organization">Organization Name</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateReturn(ReturnImportRequest request, string organization)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(new ProfulfilmentRequestContent
            {
                RequestUri = PrepareRequestUrl("remotewarehouse/imports/importitems.xml"),
                PostData = ProfulfilmentEntityRequestBody.Return(request),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "organisation", organization } }
            });
            return response;
        }

        /// <summary>
        /// The process of deleting or cancelling an order is usually driven by the third party application in which the order was first generated.The process should attempt to delete the order within the OrderFlow system before changing the status of the order within the third party system
        /// </summary>
        /// <returns></returns>
        public virtual CancelOrderRootResponse CancelOrder(CancelOrderRequest request, string channel)
        {
            var response = new CancelOrderRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            var requestUrl = PrepareRequestUrl($"remoteorder/order/cancel.xml?externalReference={request.ExternalReference}&cancelChangesExternalReference={request.CancelChangesExternalReference}");
            response.CancelOrderResponse = ExecutePostRequest<CancelOrderResponse>(new ProfulfilmentRequestContent
            {
                RequestUri = requestUrl,
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "channel", channel } }
            });
            return response;
        }

        /// <summary>
        /// This API call can be used to get a list of pending shipments for a particular sales channel.
        /// </summary>
        /// <param name="request">pending shipment request</param>
        /// <returns></returns>
        public virtual PendingShipmentRootRequest GetPendingShipments(PendingShipmentRequest request)
        {
            var response = new PendingShipmentRootRequest();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            var requestUrl = PrepareRequestUrl($"remoteorder/shipment/pending.xml?channel={request.Channel}");
            response.PendingShipments = ExecuteGetRequest<PendingShipments>(requestUrl, HttpMethod.Get);
            return response;
        }

        /// <summary>
        /// The Campaign import defines a mechanism for importing campaigns remotely. Multiple Campaign Lines can be associated with a Campaign, and multiple Campaigns can be defined in a single import. Campaigns are only present in OrderFlow from version 3.7.9
        /// </summary>
        /// <param name="request"></param>
        /// <param name="organization">Organization Name</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateCampaign(CampaignImportRequest request, string organization)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(new ProfulfilmentRequestContent
            {
                RequestUri = PrepareRequestUrl("remotewarehouse/imports/importitems.xml"),
                PostData = ProfulfilmentEntityRequestBody.Campaign(request.Import),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "organisation", organization } }
            });
            return response;
        }

        /// <summary>
        ///  get purchase order report
        /// </summary>
        /// <param name="request">purchase order report request</param>
        /// <returns></returns>
        public PurchaseOrderRootReport GetPurchaseOrderList(PurchaseOrderReportRequest request)
        {
            var response = new PurchaseOrderRootReport();
            if (string.IsNullOrEmpty(request.OrganizationId))
            {
                response.ValidatorError = "Organization id is required.";
                return response;
            }

            var requestUrl = PrepareRequestUrl(
                $"remote/report.xml?reportKey=purchase_order_lines_xml&organisation_id={request.OrganizationId}" +
                $"&startDate={request.From}&endDate={request.To}&reference={request.Reference}");
            var purchaseOrderResponse = ExecuteGetRequest<PurchaseOrderReport>(requestUrl, HttpMethod.Get);
            response.PurchaseOrderReport = purchaseOrderResponse;
            return response;
        }
    }
}