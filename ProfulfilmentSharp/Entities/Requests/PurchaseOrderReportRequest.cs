namespace ProfulfilmentSharp.Entities.Requests
{
   public class PurchaseOrderReportRequest
    {
        /// <summary>
        /// organization id
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// the date or time from which to consider
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// the date or time to which to consider
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// order external reference
        /// </summary>
        public string Reference { get; set; }
    }
}