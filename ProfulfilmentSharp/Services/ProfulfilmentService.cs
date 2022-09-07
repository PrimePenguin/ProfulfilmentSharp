using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ProfulfilmentSharp.Entities.Requests;

namespace ProfulfilmentSharp.Services
{
    public class ProfulfilmentService
    {
        protected NetworkCredential NetworkCredential { get; set; }
        protected string UserName { get; set; }
        protected string Password { get; set; }
        public byte[] Data { get; set; }

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

        public NetworkCredential BuildNetworkCredentials() => new NetworkCredential(UserName, Password);

        protected CredentialCache GetAuthHeaderCredentials(string requestUri) => new CredentialCache { { new Uri(requestUri), "Basic", NetworkCredential } };

        public string PrepareRequestUrl(string path) => $"https://wms.profulfilment.com/orderflow/test/{path}";

        protected T ExecutePostRequest<T>(RequestContent requestContent)
        {
            var request = WebRequest.Create(requestContent.RequestUri);
            request.Credentials = GetAuthHeaderCredentials(requestContent.RequestUri);
            request.Method = requestContent.HttpMethod.ToString();

            if (requestContent.PostData != null)
            {
                Data = Encoding.ASCII.GetBytes(requestContent.PostData);
                request.ContentLength = Data.Length;
            }

            if (requestContent.Headers != null)
            {
                foreach (var (key, value) in requestContent.Headers) request.Headers.Add(key, value);
            }

            if (Data != null)
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(Data, 0, Data.Length);
                }
            }

            var response = GetResponse<T>(request);
            return response;
        }

        protected T ExecuteGetRequest<T>(string requestUri, HttpMethod method)
        {
            var request = WebRequest.Create(requestUri);
            request.Method = method.ToString();
            request.Credentials = GetAuthHeaderCredentials(requestUri);
            var response = GetResponse<T>(request);
            return response;
        }

        protected T GetResponse<T>(WebRequest request)
        {
            using (var response = request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream ?? throw new InvalidOperationException()))
                    {
                        var xmlReader = new XmlTextReader(reader);
                        var xml = new XmlDocument();
                        xml.Load(xmlReader);

                        return xml.LastChild?.Name == "error"
                            ? throw new Exception(xml.InnerText)
                            : Deserialize<T>(xml);
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
            var reader = new XmlNodeReader(document);
            var serializer = new XmlSerializer(typeof(T));
            var result = (T)serializer.Deserialize(reader);
            return result;
        }
    }
}