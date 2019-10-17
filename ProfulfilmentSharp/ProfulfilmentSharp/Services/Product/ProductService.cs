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

        public virtual CreateEntityResponse CreateNewProduct(ImportProductRequest request)
        {
            var result = ExecutePostRequest<CreateEntityResponse>(new RequestContent
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
                    <import type='product' operation='insert' externalReference={product._ExternalReference}> 
                        <externalReference>{product.ExternalReference}</externalReference>
                        <description>{product.Description}</description> 
                        <weight>{product.Weight}</weight>
                        <type>{product.Type}</type> 
                        <quantityOnOrder>{product.QuantityOnOrder}</quantityOnOrder>
                        <priceNet>{product.PriceNet}</priceNet>
                        <priceGross>{product.PriceGross}</priceGross> 
                        <tax>{product.Tax}</tax> 
                        <taxCode>{product.TaxCode}</taxCode>
                        <currency>{product.Currency}</currency> 
                        <currencyUnits>{product.CurrencyUnits}</currencyUnits> 
                        <costNet>{product.CostNet}</costNet> 
                        <costGross>{product.CostGross}</costGross> 
                        <costTax>{product.CostTax}</costTax> 
                        <costTaxCode>{product.CostTaxCode}</costTaxCode>
                        <costCurrency>{product.CostCurrency}</costCurrency> 
                        <costCurrencyUnits>{product.CostCurrencyUnits}</costCurrencyUnits>
                        <userDefined1>{product.UserDefined1}</userDefined1> 
                        <userDefined2>{product.UserDefined2}</userDefined2> 
                        <userDefined3>{product.UserDefined3}</userDefined3> 
                        <userDefined4>{product.UserDefined4}</userDefined4> 
                        <userDefined5>{product.UserDefined5}</userDefined5>  
                        <activated>{product.Activated}</activated> 
                    </import> 
                </imports>
                ";
        }
    }
}