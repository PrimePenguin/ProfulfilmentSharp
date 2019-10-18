using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using ProfulfilmentSharp.Entities;
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
        public virtual Inventory GetAllInventories(string channel)
        {
            var response = new Inventory();
            if (IsNullOrEmpty(channel)) return response;

            var requestUrl = PrepareRequestUrl($"test/remotewarehouse/inventory.xml?channel={channel}");
            var result = ExecuteGetRequest<Inventory>(requestUrl, HttpMethod.Get);
            response.Products = result.Products;
            return response;
        }

        /// <summary>
        /// Create new product or update the existing product
        /// </summary>
        /// <param name="request">product data to be created</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateOrUpdateProduct(ImportProductRequest request)
        {
            var response = new CreateOrUpdateEntityRootResponse();

            var product = request.Import;
            var validatorResponse = GetValidatorResponse(product);
            if (validatorResponse.IsValid)
            {
                var result = ExecutePostRequest<CreateOrUpdateEntityResponse>(new RequestContent
                {
                    RequestUri = PrepareRequestUrl($"test/remotewarehouse/imports/importitems.xml"),
                    PostData = EntityRequestBody.GetProduct(product),
                    HttpMethod = HttpMethod.Post,
                    Headers = new Dictionary<string, string> {{"organisation", "prime_penguin"}}
                });
                response.CreateOrUpdateEntityResponse = result;
                response.IsValid = true;
                return response;
            }
            response.ValidationError = validatorResponse.Errror;
            return response;
        }

        #region Private Methods

 

        private ValidatorResponse GetValidatorResponse(object instance)
        {
            var response= new ValidatorResponse();
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