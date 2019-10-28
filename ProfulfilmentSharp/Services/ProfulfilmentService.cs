using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ProfulfilmentSharp.Entities.Requests;
using ProfulfilmentSharp.Entities.Responses;

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

        protected CredentialCache GetRequestCredentials(string requestUri)
        {
            return new CredentialCache { { new Uri(requestUri), "Basic", NetworkCredential } };
        }

        public string PrepareRequestUrl(string path) => $"https://wms.profulfilment.com/orderflow/test/{path}";

        protected T ExecuteGetRequest<T>(string requestUri, HttpMethod method)
        {
            var request = WebRequest.Create(requestUri);
            request.Method = method.ToString();
            request.Credentials = GetRequestCredentials(requestUri);
            var response = GetResponse<T>(request);
            return response;
        }

        protected T ExecutePostRequest<T>(ProfulfilmentRequestContent profulfilmentRequestContent)
        {
            var request = WebRequest.Create(profulfilmentRequestContent.RequestUri);
            request.Credentials = GetRequestCredentials(profulfilmentRequestContent.RequestUri);
            request.Method = profulfilmentRequestContent.HttpMethod.ToString();

            if (profulfilmentRequestContent.PostData != null)
            {
                Data = Encoding.ASCII.GetBytes(profulfilmentRequestContent.PostData);
                request.ContentLength = Data.Length;
            }

            // add request headers if any
            if (profulfilmentRequestContent.Headers != null)
            {
                foreach (var (key, value) in profulfilmentRequestContent.Headers) request.Headers.Add(key, value);
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
            XmlReader reader = new XmlNodeReader(document);
            var serializer = new XmlSerializer(typeof(T));
            var result = (T) serializer.Deserialize(reader);
            return result;
        }

        public static ValidatorResponse GetValidatorResponse(object instance)
        {
            var response = new ValidatorResponse();
            var context = new ValidationContext(instance, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, context, results);
            if (!isValid)
            {
                var errorBuilder = new StringBuilder();
                foreach (var validationResult in results) errorBuilder.Append(validationResult.ErrorMessage + ",");
                response.ValidationErrors = errorBuilder.ToString();
                errorBuilder.Clear();
                return response;
            }
            response.IsValidRequest = true;
            return response;
        }
    }
}