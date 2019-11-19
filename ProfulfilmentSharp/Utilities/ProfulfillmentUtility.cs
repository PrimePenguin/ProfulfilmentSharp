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
        /// <returns></returns>
        public static bool IsValidConnection(string username, string password, string channel)
        {
            var productService = new ProductService(username, password);
            var inventory = productService.GetInventory(channel);
            return inventory.Products.Count >= 0;
        }
    }
}