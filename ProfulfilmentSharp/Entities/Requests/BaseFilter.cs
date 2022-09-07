using System;
using System.ComponentModel.DataAnnotations;

namespace ProfulfilmentSharp.Entities.Requests
{
    public class BaseFilter
    {
        [Required]
        public string Channel { get; set; }
        public string From { get; set; }
        public string To { get; set; } = DateTime.UtcNow.AddDays(+1).ToString("O");
        public bool IncludeOrderLines { get; set; } = true;
    }
}
