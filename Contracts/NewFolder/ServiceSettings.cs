using System;
using System.Net.Http;

namespace ServiceContracts.NewFolder
{
    public class ServiceSettings : IServiceSettings
    {
        private readonly string _serviceUrl = "http://localhost:34909/api/";

        public ServiceSettings()
        {
            
        }
        public ServiceSettings(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }
        public string ServiceUrl { get; set; }
        HttpClient IServiceSettings.GetHttpClient()
        {
            return new HttpClient {BaseAddress = new Uri(_serviceUrl)};
        }

    }
}