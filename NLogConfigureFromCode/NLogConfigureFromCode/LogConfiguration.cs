using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Syslog;
using NLog.Targets.Syslog.Settings;
using Microsoft.Extensions.Configuration;

namespace NLogConfigureFromCode
{
    public class LogConfiguration
    {
        public void SetNLog()
        {
            var config = new LoggingConfiguration();
            const string commonLayout = "${date} ${message}";

            ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget
            {
                Layout = commonLayout
            };
            config.AddTarget("console", consoleTarget);

            FileTarget fileTarget = new FileTarget
            {
                Layout = commonLayout,
                FileName = @"C:\Users\eser.kuru\Desktop\NLogConfigureFromCode\NLogConfigureFromCode\bin\Debug\netcoreapp3.1\file.txt"
            };
            config.AddTarget("file", fileTarget);

            SyslogTarget syslogTarget = new SyslogTarget
            {
                Layout = new SimpleLayout { Text = commonLayout },
                Enforcement = new EnforcementConfig
                {
                    SplitOnNewLine = false,
                    Transliterate = false,
                    ReplaceInvalidCharacters = false,
                    TruncateFieldsToMaxLength = true,
                    TruncateMessageTo = 1024
                },
                MessageCreation = new MessageBuilderConfig
                {
                    Facility = Facility.Alert,
                    Rfc = RfcNumber.Rfc5424,
                    Rfc5424 = new Rfc5424Config
                    {
                        Hostname = "${machinename}",
                        AppName = "${logger}",
                        ProcId = "${processid}",
                        DisableBom = false
                    }
                },
                MessageSend = new MessageTransmitterConfig
                {
                    Protocol = ProtocolType.Tcp,
                    Tcp = new TcpConfig { Server = "127.0.0.1", Port = 6514 }
                }
            };
            config.AddTarget("syslog", syslogTarget);

            LoggingRule consoleLoggingRule = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(consoleLoggingRule);

            LoggingRule fileLoggingRule = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(fileLoggingRule);

            LoggingRule syslogLoggingRule = new LoggingRule("*", LogLevel.Info, LogLevel.Info, syslogTarget);
            config.LoggingRules.Add(syslogLoggingRule);

            LogManager.Configuration = config;
        }
    }
}
