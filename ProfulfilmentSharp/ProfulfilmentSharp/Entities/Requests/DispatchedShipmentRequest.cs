using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class DispatchedShipmentRequest
    {
        /// <summary>
        /// the channel under consideration
        /// </summary>
        [Required]
        public string Channel { get; set; }

        /// <summary>
        /// the date or time from which to consider
        /// </summary>
        [Required]
        public string From { get; set; }

        /// <summary>
        ///  the date or time to which to consider
        /// </summary>
        [Required]
        public string To { get; set; }

        /// <summary>
        /// to include order lines in the shipment
        /// </summary>
        public bool IncludeOrderLines { get; set; }
    }
}
