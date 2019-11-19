using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class OrderByReferenceRequest
    {
        /// <summary>
        ///  channel name
        /// </summary>
        [Required]
        public string Channel { get; set; }

        /// <summary>
        ///  unique identifier of the order
        /// </summary>
        [Required] public string ExternalReference { get; set; }
    }
}