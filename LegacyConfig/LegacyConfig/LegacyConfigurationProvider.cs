using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LegacyConfig
{
    public class LegacyConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        public override void Load()
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                Data.Add($"ConnectionStrings:{connectionString.Name}", connectionString.ConnectionString);
            }

            foreach (var settingKey in ConfigurationManager.AppSettings.AllKeys)
            {
                Data.Add(settingKey, ConfigurationManager.AppSettings[settingKey]);
            }
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }
    }
}
