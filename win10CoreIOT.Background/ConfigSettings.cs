using System;
using System.IO;
using Windows.ApplicationModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace win10CoreIOT.Background
{
    public sealed class ConfigSettings
    {
        const string ConfigurationFile = "app.json";
        public string GetWebAPISetting(string AppSetting)
        {
            try
            {
                string filePath = Path.Combine(Package.Current.InstalledLocation.Path, ConfigurationFile);
                using (StreamReader file = File.OpenText(filePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    var jObject = (JObject)JToken.ReadFrom(reader);
                    //"WebAPI"
                    var attrib1 = jObject.GetValue(AppSetting).Value<string>();
                    return attrib1;
                }
                // Data is contained in timestamp
            }
            catch (Exception ex)
            {
                // Timestamp not found
                return ex.Message;
            }
        }
    }
}
