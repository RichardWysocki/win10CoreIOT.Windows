﻿using System;
using System.Net.Http;
using Management.Library;

namespace Management.Library
{
    public class ServiceSetting : IServiceSetting
    {
        private readonly string _serviceUrl = "http://localhost:34909/api/";

        public ServiceSetting()
        {
            
        }
        public ServiceSetting(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }
        public string ServiceUrl { get; set; }
        HttpClient IServiceSetting.GetHttpClient()
        {
            return new HttpClient {BaseAddress = new Uri(_serviceUrl)};
        }

    }
}