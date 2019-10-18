using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Get Order by external reference
        /// </summary>
        /// <param name="request">order by reference request</param>
        /// <returns></returns>
        public virtual OrderRootResponse GetOrderByExternalReference(OrderByReferenceRequest request)
        {
            var response = new OrderRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValid)
            {
                response.ValidationError = validatorResponse.Errror;
                return response;
            }
            var requestUrl = PrepareRequestUrl(
                $"test/remoteorder/order/detail.xml?channel={request.Channel}&externalReference={request.ExternalReference}");
            var result = ExecuteGetRequest<Entities.Order>(requestUrl, HttpMethod.Get);
            response.Order = result;
            return response;
        }

        /// <summary>
        /// Get dispatched shipment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual RootDispatchedShipments GetDispatchedShipmentByDate(DispatchedShipmentRequest request)
        {
            var response = new RootDispatchedShipments();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValid)
            {
                response.ValidationError = validatorResponse.Errror;
                return response;
            }
            var requestUrl =
                PrepareRequestUrl(
                    $"test/remoteorder/shipment/despatches.xml?channel={request.Channel}&from={request.From}&to={request.To}");
            response.DispatchedShipments = ExecuteGetRequest<DispatchedShipments>(requestUrl, HttpMethod.Get);
            return response;
        }

        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="request">order data to be created</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateNewOrder(ImportOrderRequest request)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValid)
            {
                response.ValidationError = validatorResponse.Errror;
                return response;
            }
            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(new RequestContent
            {
                RequestUri = PrepareRequestUrl($"test/remoteorder/imports/importitems.xml"),
                PostData = EntityRequestBody.GetOderBody(request),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "channel", "channel1" } }
            });
            return response;
        }

        /// <summary>
        /// Import Supplier purchase order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse SupplierPurchaseOrderImport(SupplierPurchaseOrderImportRequest request)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValid)
            {
                response.ValidationError = validatorResponse.Errror;
                return response;
            }
            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(new RequestContent
            {
                RequestUri = PrepareRequestUrl($"test/remotewarehouse/imports/importitems.xml"),
                PostData = EntityRequestBody.GetSupplierPurchaseOrderBody(request.PurchaseOrder),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "organisation", "prime_penguin" } }
            });
            return response;
        }

        /// <summary>
        /// import return
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse ReturnImport(ReturnImportRequest request)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValid)
            {
                response.ValidationError = validatorResponse.Errror;
                return response;
            }
            response.CreateOrUpdateEntityResponse = ExecutePostRequest<CreateOrUpdateEntityResponse>(new RequestContent
            {
                RequestUri = PrepareRequestUrl($"test/remotewarehouse/imports/importitems.xml"),
                PostData = EntityRequestBody.GetReturnImportBody(request),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "organisation", "prime_penguin" } }
            });
            return response;
        }

        /// <summary>
        /// The process of deleting or cancelling an order is usually driven by the third party application in which the order was first generated.The process should attempt to delete the order within the OrderFlow system before changing the status of the order within the third party system
        /// </summary>
        /// <returns></returns>
        public virtual CancelOrderRootResponse CancelOrder(CancelOrderRequest request)
        {
            var response = new CancelOrderRootResponse();
            var validatorResponse = GetValidatorResponse(request);
            if (!validatorResponse.IsValid)
            {
                response.ValidationError = validatorResponse.Errror;
                return response;
            }
            var requestUrl = PrepareRequestUrl(
                $"test/remoteorder/order/cancel.xml?externalReference={request.ExternalReference}&cancelChangesExternalReference={request.CancelChangesExternalReference}");
            response.CancelOrderResponse = ExecutePostRequest<CancelOrderResponse>(new RequestContent
            {
                RequestUri = requestUrl,
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "channel", "channel1" } }
            });
            return response;
        }

        #region Private Methods

        private ValidatorResponse GetValidatorResponse(object instance)
        {
            var response = new ValidatorResponse();
            var context = new ValidationContext(instance, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, context, results);
            if (!isValid)
            {
                var errorBuilder = new StringBuilder();
                foreach (var validationResult in results) errorBuilder.Append(validationResult.ErrorMessage + ",");
                response.Errror = errorBuilder.ToString();
                errorBuilder.Clear();
                return response;
            }
            response.IsValid = true;
            return response;
        }

        #endregion
    }
}