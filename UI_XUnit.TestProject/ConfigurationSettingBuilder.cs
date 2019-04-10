
using Microsoft.Extensions.Configuration;
using System;

namespace UI_XUnit.TestProject
{
    public static class ConfigurationSettingBuilder
    {
        private static IConfigurationRoot configurationRoot = new ConfigurationBuilder().AddJsonFile("AppSetting.json").Build();

        public static string GetSetting(string configName)
    {
        //configurationRoot = new ConfigurationBuilder().AddJsonFile("client-secrets.json").Build();
            var response = configurationRoot[configName];
        if (string.IsNullOrEmpty(response))
        {
            throw new Exception($"Invalid Configuration for {configName}");
        }
        return response;
    }

    //    var clientId = config["AUTH0_CLIENT_ID"]
    }
}
