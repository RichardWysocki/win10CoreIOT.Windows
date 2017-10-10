using System.Net.Http;

namespace ServiceContracts
{
    public interface IServiceSettings
    {
        string ServiceUrl { get; set; }

        HttpClient GetHttpClient();
    }
}