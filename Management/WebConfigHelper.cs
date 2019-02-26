using System;
using System.Configuration;


namespace Management
{
    public static class WebConfigHelper
    {
        public static string GetSetting(string configName)
        {
            var response = ConfigurationManager.AppSettings[configName];
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception($"Invalid Configuration for {configName}");
            }
            return response;
        }
    }
}