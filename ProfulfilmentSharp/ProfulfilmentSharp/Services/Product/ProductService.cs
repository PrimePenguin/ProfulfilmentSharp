using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using ProfulfilmentSharp.Entities;
using ProfulfilmentSharp.Entities.ProfulfilmentRequests;
using ProfulfilmentSharp.Entities.ProfulfilmentResponses;
using static System.String;

namespace ProfulfilmentSharp.Services.Product
{
    public class ProductService : ProfulfilmentService
    {
        public ProductService(string userName, string password) : base(userName, password)
        {
        }

        /// <summary>
        /// Get all inventories
        /// </summary>
        /// <param name="channel">channel name</param>
        /// <returns></returns>
        public virtual Inventory GetInventories(string channel)
        {
            var response = new Inventory();
            if (IsNullOrEmpty(value: channel)) throw new Exception("Channel name is required.");

            var requestUrl = PrepareRequestUrl($"remotewarehouse/inventory.xml?channel={channel}");
            var result = ExecuteGetRequest<Inventory>(requestUri: requestUrl, method: HttpMethod.Get);
            response.Products = result.Products;
            return response;
        }

        /// <summary>
        ///  Adding new products into the OrderFlow database, and for updating existing products
        /// </summary>
        /// <param name="request">product data to be created or updated</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateOrUpdateProduct(ImportProductRequest request)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var product = request.Import;
            var validatorResponse = GetValidatorResponse(product);
            if (validatorResponse.IsValidRequest)
            {
                var result = ExecutePostRequest<CreateOrUpdateEntityResponse>(new ProfulfilmentRequestContent
                {
                    RequestUri = PrepareRequestUrl($"remotewarehouse/imports/importitems.xml"),
                    PostData = ProfulfilmentEntityRequestBody.Product(product: product),
                    HttpMethod = HttpMethod.Post,
                    Headers = new Dictionary<string, string> {{"organisation", "prime_penguin"}}
                });
                response.CreateOrUpdateEntityResponse = result;
                return response;
            }
            response.ValidationError = validatorResponse.ValidationErrors;
            return response;
        }

        /// <summary>
        /// It is used by OrderFlow to PUSH stock levels to Third Party applications when a change in stock levels triggers the event or as a scheduled background processes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual InventoryPushRootRequest PushInventory(InventoryPushRequest request)
        {
            var response = new InventoryPushRootRequest();
            var validatorResponse = GetValidatorResponse(instance: request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }
            response.InventoryPushRequest = ExecutePostRequest<object>(new ProfulfilmentRequestContent
            {
                RequestUri = PrepareThirdPartyRequestUrl($"productInventory.xml"),
                PostData = ProfulfilmentEntityRequestBody.InventoryPush(request: request),
                HttpMethod = HttpMethod.Post
            });
            return response;
        }

        /// <summary>
        /// import return
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual InventoryPushRootRequest DeliveryLinePush(InventoryPushRequest request)
        {
            var response = new InventoryPushRootRequest();
            var validatorResponse = GetValidatorResponse(instance: request);
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }

            response.InventoryPushRequest = ExecutePostRequest<object>(new ProfulfilmentRequestContent
            {
                RequestUri = PrepareThirdPartyRequestUrl($"deliveryLine.xml"),
                PostData = ProfulfilmentEntityRequestBody.InventoryPush(request: request),
                HttpMethod = HttpMethod.Post
            });
            return response;
        }

        #region Private Methods

        private static ValidatorResponse GetValidatorResponse(object instance)
        {
            var response= new ValidatorResponse();
            var context = new ValidationContext(instance, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, context, results);
            if (!isValid)
            {
                var errorBuilder = new StringBuilder();
                foreach (var validationResult in results) errorBuilder.Append(validationResult.ErrorMessage + ",");
                response.ValidationErrors = errorBuilder.ToString();
                errorBuilder.Clear();
                return response;
            }
            response.IsValidRequest = true;
            return response;
        }

        #endregion
    }
}