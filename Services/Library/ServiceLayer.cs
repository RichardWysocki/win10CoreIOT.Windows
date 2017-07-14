using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

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

        public void SendDelete<T>(string api, int data)
        {
            var getData = _serviceSetting.GetHttpClient();
            var response = getData.DeleteAsync(api +"/"+ data).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("This didn't work!!!");
        }

        public T GetItem<T>(string api, int id)
        {
            var getData = _serviceSetting.GetHttpClient();
            var response = getData.GetAsync(api + "/" + id).Result;
            var data = response.Content.ReadAsAsync<T>().Result;
            return data;
        }

        public T Update<T>(string api, T data)
        {
            var getData = _serviceSetting.GetHttpClient();
            var jsonString = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = getData.PutAsync(api, httpContent).Result;
            if (response.IsSuccessStatusCode)
                Console.Write("Success");
            else
                Console.Write("Error");
            var returndata = response.Content.ReadAsAsync<T>().Result;
            return returndata;
        }
    }
}