using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using ProfulfilmentSharp.Entities;
using ProfulfilmentSharp.Entities.Requests;
using ProfulfilmentSharp.Entities.Responses;
using static System.String;

namespace ProfulfilmentSharp.Services.Product
{
    public class ProductService : ProfulfilmentService
    {
        public ProductService(string userName, string password) : base(userName, password)
        {
        }

        /// <summary>
        /// This operation can return the inventory level for just a single product, a particular set of products or for all products in the inventory for a particular retailer.
        /// </summary>
        /// <param name="channel">channel name</param>
        /// <returns></returns>
        public virtual Inventory PullInventory(string channel)
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