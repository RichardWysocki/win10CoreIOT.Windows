using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Services.Library
{
    public class ServiceLayer : IServiceLayer
    {
        public List<T> GetData<T>()
        {
            var getData = new HttpClient();
            var response = getData.GetAsync(new Uri("http://localhost:34909/api/LogInfo")).Result;
            var data = response.Content.ReadAsAsync<List<T>>().Result;

            return data;
        }

        public void SendData<T>(T data)
        {
            var getData = new HttpClient();
            var objectData = data;
            var response = getData.PostAsJsonAsync(new Uri("http://localhost:34909/api/LogInfo"), objectData).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("This didn't work!!!");
        }
    }
}