using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ServiceContracts.NewFolder
{
    public class ServiceLayers : IServiceLayers
    {
        private readonly IServiceSettings _serviceSetting;

        public ServiceLayers(IServiceSettings serviceSetting )
        {
            _serviceSetting = serviceSetting; //new ServiceSetting("http://localhost:34909/api/");
        }

        public List<T> GetData<T>(string api)
        {
            var getData = _serviceSetting.GetHttpClient();
            var response = getData.GetAsync(api).Result;
            var data = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);
            return data;
        }

        public void SendData<T>(string api, T data)
        {
            var getData = _serviceSetting.GetHttpClient();

            string postBody = JsonConvert.SerializeObject(data);
            getData.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage wcfResponse = getData.PostAsync(api, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;


            //var response = getData.PostAsJsonAsync(api, data).Result;
            if (!wcfResponse.IsSuccessStatusCode)
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
            var data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
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
            var returndata = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            return returndata;
        }
    }
}