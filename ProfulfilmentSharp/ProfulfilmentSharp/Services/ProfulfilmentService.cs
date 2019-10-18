using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ProfulfilmentSharp.Entities;

namespace ProfulfilmentSharp.Services
{
    public class ProfulfilmentService
    {
        protected NetworkCredential NetworkCredential { get; set; }

        protected string UserName { get; set; }

        protected string Password { get; set; }
        public byte[] _data { get; set; } = null;

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

        protected CredentialCache GetRequestCredentials(string requestUri)
        {
            return new CredentialCache { { new Uri(requestUri), "Basic", NetworkCredential } };
        }

        public string PrepareRequestUrl(string path) => $"https://wms.profulfilment.com/orderflow/{path}";

        protected T ExecuteGetRequest<T>(string requestUri, HttpMethod method)
        {
            var request = WebRequest.Create(requestUri);
            request.Method = method.ToString();
            request.Credentials = GetRequestCredentials(requestUri);
            var response = GetResponse<T>(request);
            return response;
        }

        protected T ExecutePostRequest<T>(RequestContent requestContent)
        {
            var request = WebRequest.Create(requestContent.RequestUri);
            request.Credentials = GetRequestCredentials(requestContent.RequestUri);
            request.Method = requestContent.HttpMethod.ToString();

            if (requestContent.PostData != null)
            {
                _data = Encoding.ASCII.GetBytes(requestContent.PostData);
                request.ContentLength = _data.Length;
            }

            // add request headers if any
            if (requestContent.Headers != null)
            {
                foreach (var (key, value) in requestContent.Headers) request.Headers.Add(key, value);
            }

            if (_data != null)
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(_data, 0, _data.Length);
                }
            }
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
                        // uncomment following line to see the actual data returned from API.
                        //var actualData = reader.ReadToEnd();  

                        var xmlReader = new XmlTextReader(reader);
                        var serializer = new XmlSerializer(typeof(T));
                        var result = (T)serializer.Deserialize(xmlReader);
                        return result;
                    }
                }
            }
        }
    }
}