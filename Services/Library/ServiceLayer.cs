using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Services.Library
{
    public class ServiceLayer : IServiceLayer
    {
        private readonly IServiceSetting _serviceSetting;

        public ServiceLayer(IServiceSetting serviceSetting )
        {
            _serviceSetting = serviceSetting; //new ServiceSetting("http://localhost:34909/api/");
        }

        public List<T> GetData<T>(string api)
        {
            var getData = _serviceSetting.GetHttpClient();
            var response = getData.GetAsync(api).Result;
            var data = response.Content.ReadAsAsync<List<T>>().Result;

            return data;
        }

        public void SendData<T>(string api, T data)
        {
            var getData = _serviceSetting.GetHttpClient();
            var response = getData.PostAsJsonAsync(api, data).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("This didn't work!!!");
        }
    }
}