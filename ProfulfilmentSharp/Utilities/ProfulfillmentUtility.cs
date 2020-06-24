using System;
using ProfulfilmentSharp.Services;

namespace ProfulfilmentSharp.Utilities
{
    public static class ProfulfillmentUtility
    {
        /// <summary>
        ///  check whether the credentials are valid or not
        /// </summary>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <param name="channel">channel name</param>
        /// <param name="externalReference">default inventory externalReference</param>
        /// <returns></returns>
        public static bool IsValidConnection(string username, string password, string channel, string externalReference = "100000000000")
        {
            var productService = new ProductService(username, password);
            try
            {
                var inventory = productService.GetInventory(channel, externalReference);
                return inventory.Products == null || inventory.Products.Count >= 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}