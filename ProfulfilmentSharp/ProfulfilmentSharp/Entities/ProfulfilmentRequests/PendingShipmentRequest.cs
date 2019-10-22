using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.ProfulfilmentRequests
{
    public class PendingShipmentRequest
    {
        [Required]
        public string Channel { get; set; }
    }
}