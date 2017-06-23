using System.Net.Http;

namespace Services.Library
{
    public interface IServiceSetting
    {
        string ServiceUrl { get; set; }

        HttpClient GetHttpClient();
    }
}