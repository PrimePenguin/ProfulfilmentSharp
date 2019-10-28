using System;
using System.Collections.Generic;
using System.Net.Http;
using ProfulfilmentSharp.Entities;
using ProfulfilmentSharp.Entities.Requests;
using ProfulfilmentSharp.Entities.Responses;

namespace ProfulfilmentSharp.Services
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
        public virtual Inventory GetInventory(string channel)
        {
            var response = new Inventory();
            if (string.IsNullOrEmpty(channel)) throw new Exception("Channel name is required.");

            var requestUrl = PrepareRequestUrl($"remotewarehouse/inventory.xml?channel={channel}");
            var result = ExecuteGetRequest<Inventory>(requestUrl, HttpMethod.Get);
            response.Products = result.Products;
            return response;
        }

        /// <summary>
        ///  Adding new products into the OrderFlow database, and for updating existing products
        /// </summary>
        /// <param name="request">product data to be created or updated</param>
        /// <param name="organization">Organization Name</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateOrUpdateProduct(ImportProductRequest request, string organization)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var product = request.Import;
            var validatorResponse = GetValidatorResponse(product);
            if (validatorResponse.IsValidRequest)
            {
                var result = ExecutePostRequest<CreateOrUpdateEntityResponse>(new ProfulfilmentRequestContent
                {
                    RequestUri = PrepareRequestUrl("remotewarehouse/imports/importitems.xml"),
                    PostData = ProfulfilmentEntityRequestBody.Product(product),
                    HttpMethod = HttpMethod.Post,
                    Headers = new Dictionary<string, string> {{"organisation", organization}}
                });
                response.CreateOrUpdateEntityResponse = result;
                return response;
            }
            response.ValidationError = validatorResponse.ValidationErrors;
            return response;
        }
    }
}