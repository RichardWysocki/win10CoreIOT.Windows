using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Services.Library
{
    public interface IServiceLayer
    {
        List<T> GetData<T>();


        void SendData<T>(T data);
    }
}