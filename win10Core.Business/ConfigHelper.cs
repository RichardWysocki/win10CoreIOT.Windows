using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
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
