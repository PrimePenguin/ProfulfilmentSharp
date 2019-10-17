using System.Collections.Generic;
using System.Net.Http;
using ProfulfilmentSharp.Entities;

namespace ProfulfilmentSharp.Services.Product
{
    public class ProductService : ProfulfilmentService
    {
        public ProductService(string userName, string password) : base(userName, password)
        {
        }

        public virtual Inventory GetAllInventories(string channel)
        {
            var requestUrl = PrepareRequestUrl($"test/remotewarehouse/inventory.xml?channel={channel}");
            return ExecuteGetRequest<Inventory>(requestUrl, HttpMethod.Get);
        }

        public virtual CreateOrUpdateEntityResponse CreateOrUpdateProduct(ImportProductRequest request)
        {
            var result = ExecutePostRequest<CreateOrUpdateEntityResponse>(new RequestContent
            {
                RequestUri = PrepareRequestUrl($"test/remotewarehouse/imports/importitems.xml"),
                Content = GetProduct(request.Import),
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> {{"organisation", "prime_penguin"}}
            });
            return result;
        }

        private static string GetProduct(Import product)
        {
            return $@"
                <imports>
                    <import type='product' operation='{product.Operation}' externalReference={product._ExternalReference}> 
                        externalReference={product.ExternalReference}
                        description={product.Description}
                        weight={product.Weight}
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
                    </import> 
                </imports>
                ";
        }
    }
}