using System.Collections.Generic;
using System.Net.Http;

namespace ProfulfilmentSharp.Entities
{
    public  class RequestContent
    {
        public string  RequestUri { get; set; }
        public string Content { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public IDictionary<string,string> Headers { get; set; }
    }
}