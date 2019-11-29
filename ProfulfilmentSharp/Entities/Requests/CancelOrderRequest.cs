using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class CancelOrderRequest
    {
        public CancelOrderRequest()
        {
            CancelChangesExternalReference = true;
        }

        /// <summary>
        /// the reference of the order to be cancelled
        /// </summary>
        [Required]
        public string ExternalReference { get; set; }

        /// <summary>
        ///  If set to false, the order reference will not be changed.Because OrderFlow does not allow duplicates of orders with the same reference it will not be possible to reimport the same order.
        /// For some third party systems, a temporary cancellation of the order is required in order to support the reimport of a modified order.In this case, the old order needs to be cancelled in a way that will allow the same(but modified) order to be reimported into the system. In this case the cancelChangesExternalReference parameter is used with the value of true
        /// </summary>
        public bool CancelChangesExternalReference { get; set; }
    }
}