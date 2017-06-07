using System;
using System.Configuration;

namespace win10Core.Business
{
    public static class ConfigHelper
    {
        public static string GetSetting(string configName)
        {
            var response = ConfigurationManager.AppSettings[configName];
            if (string.IsNullOrEmpty(response))
{
                throw new Exception($"InValid Configuration for {configName}");
            }
            return response;
        }
    }
}
