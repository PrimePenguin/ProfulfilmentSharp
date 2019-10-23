namespace ProfulfilmentSharp.Entities.Responses
{
    public class ValidatorResponse
    {
        public bool IsValidRequest { get; set; }
        public string ValidationErrors { get; set; }
    }   
}