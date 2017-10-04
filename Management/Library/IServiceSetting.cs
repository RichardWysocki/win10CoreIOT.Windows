using System.Net.Http;

namespace Management.Library
{
    public interface IServiceSetting
    {
        string ServiceUrl { get; set; }

        HttpClient GetHttpClient();
    }
}