using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "message")]
    public class CancelOrderResponse
    {
        [XmlText] public string Text { get; set; }
    }

    public class CancelOrderRootResponse
    {
        public CancelOrderRootResponse()
        {
            CancelOrderResponse = null;
        }
        public string ValidationError { get; set; }
        public bool IsValid { get; set; }
        public CancelOrderResponse CancelOrderResponse { get; set; }
    }
}