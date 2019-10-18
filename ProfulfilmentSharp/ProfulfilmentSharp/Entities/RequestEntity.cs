using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities
{
    public class OrderByReferenceRequest
    {
        [Required] public string Channel { get; set; }
        [Required] public string ExternalReference { get; set; }
    }

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

    public class CancelOrderRequest
    {
        /// <summary>
        /// the reference of the order to be cancelled
        /// </summary>
        [Required]
        public string ExternalReference { get; set; }

        /// <summary>
        /// whether cancellation should change the order reference
        /// </summary>
        public bool CancelChangesExternalReference { get; set; }
    }
}