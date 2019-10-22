using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.ProfulfilmentRequests
{
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