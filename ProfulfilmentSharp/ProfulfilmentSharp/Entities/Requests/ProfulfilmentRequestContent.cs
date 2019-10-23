using System.Collections.Generic;
using System.Net.Http;

namespace ProfulfilmentSharp.Entities.Requests
{
    public  class ProfulfilmentRequestContent
    {
        public string  RequestUri { get; set; }
        public string PostData { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public IDictionary<string,string> Headers { get; set; }
    }
}