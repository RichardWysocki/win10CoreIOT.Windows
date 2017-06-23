using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Services.Library
{
    public interface IServiceLayer
    {
        List<T> GetData<T>(string api);


        void SendData<T>(string api, T data);
    }
}