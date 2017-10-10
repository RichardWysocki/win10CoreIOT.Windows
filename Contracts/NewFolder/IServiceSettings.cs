using System.Net.Http;

namespace ServiceContracts.NewFolder
{
    public interface IServiceSettings
    {
        string ServiceUrl { get; set; }

        HttpClient GetHttpClient();
    }
}