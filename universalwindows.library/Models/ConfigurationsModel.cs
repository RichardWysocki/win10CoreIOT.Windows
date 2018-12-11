using System.Runtime.Serialization;

namespace universalwindows.library.Models
{
    [DataContract]
    public class ConfigurationsModel
    {
        public ConfigurationsModel()
        {
        }

        [DataMember]
        public string WebsiteURL { get; set; }
    }
}
