using Microsoft.Extensions.Configuration;
using System;

namespace ComputerDatabase.Qa.UI.Tests.Configuration
{
    public sealed class Configuration
    {
        public static T GetConfiguration<T>(string key)
        {
            var appSetting = string.Empty;
            try
            {
                appSetting = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()[key];

                if (appSetting == null)
                {
                    throw new Exception($"Missing configuration value: {key}");
                }
                return (T)Convert.ChangeType(appSetting, typeof(T));
            }
            catch (Exception ex)
            {
                throw new Exception($"Invalid configuration value cast: {key} to type {typeof(T).FullName} value was {appSetting}", ex);
            }

        }
    }
}
