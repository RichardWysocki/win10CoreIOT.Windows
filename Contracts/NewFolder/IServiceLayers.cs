using System.Collections.Generic;

namespace ServiceContracts.NewFolder
{
    public interface IServiceLayers
    {
        List<T> GetData<T>(string api);

        void SendData<T>(string api, T data);

        void SendDelete<T>(string api, int data);

        T GetItem<T>(string api, int id);

        T Update<T>(string api, T data);
    }
}