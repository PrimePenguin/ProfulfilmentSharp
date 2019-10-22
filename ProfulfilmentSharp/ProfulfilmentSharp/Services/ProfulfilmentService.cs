using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ProfulfilmentSharp.Entities.ProfulfilmentRequests;

namespace ProfulfilmentSharp.Services
{
    public class ProfulfilmentService
    {
        protected NetworkCredential NetworkCredential { get; set; }

        protected string UserName { get; set; }

        protected string Password { get; set; }
        public byte[] _data { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ProfulfilmentService" />.
        /// </summary>
        /// <param name="userName">app user name</param>
        /// <param name="password">app password</param>
        protected ProfulfilmentService(string userName, string password)
        {
            UserName = userName;
            Password = password;
            NetworkCredential = BuildNetworkCredentials();
        }

        public NetworkCredential BuildNetworkCredentials() => new NetworkCredential(userName: UserName, password: Password);

        protected CredentialCache GetRequestCredentials(string requestUri)
        {
            return new CredentialCache { { new Uri(uriString: requestUri), "Basic", NetworkCredential } };
        }

        public string PrepareRequestUrl(string path) => $"https://wms.profulfilment.com/orderflow/test/{path}";

        public string PrepareThirdPartyRequestUrl(string path) => $"https://thirdpartyurl/{path}";

        protected T ExecuteGetRequest<T>(string requestUri, HttpMethod method)
        {
            var request = WebRequest.Create(requestUriString: requestUri);
            request.Method = method.ToString();
            request.Credentials = GetRequestCredentials(requestUri: requestUri);
            var response = GetResponse<T>(request: request);
            return response;
        }

        protected T ExecutePostRequest<T>(ProfulfilmentRequestContent profulfilmentRequestContent)
        {
            var request = WebRequest.Create(requestUriString: profulfilmentRequestContent.RequestUri);
            request.Credentials = GetRequestCredentials(requestUri: profulfilmentRequestContent.RequestUri);
            request.Method = profulfilmentRequestContent.HttpMethod.ToString();

            if (profulfilmentRequestContent.PostData != null)
            {
                _data = Encoding.ASCII.GetBytes(s: profulfilmentRequestContent.PostData);
                request.ContentLength = _data.Length;
            }

            // add request headers if any
            if (profulfilmentRequestContent.Headers != null)
            {
                foreach (var (key, value) in profulfilmentRequestContent.Headers) request.Headers.Add(key, value: value);
            }

            if (_data != null)
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(_data, 0, _data.Length);
                }
            }

            var response = GetResponse<T>(request: request);
            return response;
        }

        protected T GetResponse<T>(WebRequest request)
        {
            using (var response = request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream: dataStream ?? throw new InvalidOperationException()))
                    {  
                        var xmlReader = new XmlTextReader(input: reader);
                        var xml = new XmlDocument();
                        xml.Load(reader: xmlReader);

                        return xml.LastChild?.Name == "error"
                            ? throw new Exception(message: xml.InnerText)
                            : Deserialize<T>(document: xml);
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes XmlDocument object to Serializable object of type T.
        /// </summary>
        /// <typeparam name="T">Serializable object type as output type.</typeparam>
        /// <param name="document">XmlDocument object to be deserialized.</param>
        /// <returns>Deserialized serializable object of type T.</returns>
        public T Deserialize<T>(XmlDocument document)
        {
            XmlReader reader = new XmlNodeReader(node: document);
            var serializer = new XmlSerializer(type: typeof(T));
            var result = (T) serializer.Deserialize(xmlReader: reader);
            return result;
        }
    }
}