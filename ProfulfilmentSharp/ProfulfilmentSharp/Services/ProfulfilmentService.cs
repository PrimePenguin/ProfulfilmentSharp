﻿using System;
using System.IO;
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
            using (var response = request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream ?? throw new InvalidOperationException()))
                    {
                        var xmlReader = new XmlTextReader(reader);
                        var serializer = new XmlSerializer(typeof(T));
                        var result = (T)serializer.Deserialize(xmlReader);
                        return result;
                    }
                }
            }
        }

        protected T ExecutePostRequest<T>(RequestContent requestContent)
        {
            var request = WebRequest.Create(requestContent.RequestUri);
            var data = Encoding.ASCII.GetBytes(requestContent.Content);
            request.Credentials = GetRequestCredentials(requestContent.RequestUri);
            request.Method = requestContent.HttpMethod.ToString();
            request.ContentLength = data.Length;

            // add request headers if any
            foreach (var (key, value) in requestContent.Headers) request.Headers.Add(key, value);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream ?? throw new InvalidOperationException()))
                    {
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