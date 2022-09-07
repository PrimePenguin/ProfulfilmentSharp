using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        /// <param name="externalReferences">product codes for which to retrieve inventories (optional) If no externalReferences are supplied the system will return all products associated with the channel, for which inventory exists.</param>
        /// <returns></returns>
        public virtual List<Product> GetInventory(string channel, string externalReferences = null)
        {
            if (string.IsNullOrEmpty(channel)) throw new Exception("Channel name is required.");

            var requestUrl = new StringBuilder();
            requestUrl.Append(PrepareRequestUrl($"remotewarehouse/inventory.xml?channel={channel}"));
            if (!string.IsNullOrEmpty(externalReferences)) requestUrl.Append($"&externalReferences={externalReferences}");

            var result = ExecuteGetRequest<Inventory>(requestUrl.ToString(), HttpMethod.Get);
            return result?.Products.Where(c => !string.IsNullOrEmpty(c.ExternalReference)).ToList();
        }

        /// <summary>
        ///  Adding new products into the OrderFlow database, and for updating existing products
        /// </summary>
        /// <param name="request">product data to be created or updated</param>
        /// <param name="organization">Organization Name</param>
        /// <returns></returns>
        public virtual CreateOrUpdateEntityRootResponse CreateOrUpdateProduct(ProfulfilmentProduct request, string organization)
        {
            var response = new CreateOrUpdateEntityRootResponse();
            var validatorResponse = request.Validate();
            if (!validatorResponse.IsValidRequest)
            {
                response.ValidationError = validatorResponse.ValidationErrors;
                return response;
            }

            var result = ExecutePostRequest<CreateOrUpdateEntityResponse>(new RequestContent
            {
                RequestUri = PrepareRequestUrl("remotewarehouse/imports/importitems.xml"),
                PostData = ProfulfilmentEntityRequest.GenerateProductPayload(request),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "organisation", organization } }
            });

            response.CreateOrUpdateEntityResponse = result;
            return response;
        }
    }
}