using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class OrderByReferenceRequest
    {
        [Required] public string Channel { get; set; }
        [Required] public string ExternalReference { get; set; }
    }
}