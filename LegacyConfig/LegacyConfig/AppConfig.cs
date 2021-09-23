using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegacyConfig
{
    public class AppConfig
    {
        public string ApplicationName { get; set; }
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public ApiSettingsConfig ApiSettings { get; set; }

        public class ConnectionStringsConfig
        {
            public string MyDb { get; set; }
            public string MyLegacyDb { get; set; }
        }

        public class ApiSettingsConfig
        {
            public string Url { get; set; }
            public string ApiKey { get; set; }
            public bool UseCache { get; set; }
        }
    }
}
