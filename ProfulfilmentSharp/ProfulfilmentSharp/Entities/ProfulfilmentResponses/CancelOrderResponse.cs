using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities.ProfulfilmentResponses
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
        public CancelOrderResponse CancelOrderResponse { get; set; }
    }
}