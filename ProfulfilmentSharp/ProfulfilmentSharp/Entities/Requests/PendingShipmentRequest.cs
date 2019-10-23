using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class PendingShipmentRequest
    {
        [Required]
        public string Channel { get; set; }
    }
}