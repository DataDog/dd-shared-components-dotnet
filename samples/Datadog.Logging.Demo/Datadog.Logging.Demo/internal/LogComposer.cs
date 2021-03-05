﻿// <auto-generated />
// This .CS file is automatically generated. If you modify its contents, your changes will be overwritten.
// Modify the respective T4 templates if changes are required.

// <auto-generated />
// ----------- ----------- ----------- ----------- -----------
// The source code below is included via a T4 template.
// The template calling must specify the value of the <c>NamespacesAndMonikersOfLogsToCompose</c> meta-variable.
// ----------- ----------- ----------- ----------- -----------

using System;
using System.Collections.Generic;

namespace Datadog.Logging.Composition
{
    /// <summary>
    /// Collects data from many Log-sources and sends it to the specified Log Sink.
    /// This class has been generated using a T4 template. It covers the following logging components:
    ///   1) Logger type:               "Datadog.Logging.Demo.Log"
    ///      Logging component moniker: "LoggingDemo"
    ///
    /// TOTAL: 1 loggers.
    /// </summary>
    internal static class LogComposer
    {
        private const string IsDebugLoggingEnabledEnvVarName = "DD_TRACE_DEBUG";

        private static bool s_isDebugLoggingEnabled = true;

        public static bool IsDebugLoggingEnabled
        {
            get
            {
                return s_isDebugLoggingEnabled;
            }

            set
            {
                s_isDebugLoggingEnabled = value;
                {
                    global::Datadog.Logging.Demo.Log.Configure.DebugLoggingEnabled(s_isDebugLoggingEnabled);
                }
            }
        }

        public static void SetDebugLoggingEnabledBasedOnEnvironment()
        {
            bool envSetting = GetDebugLoggingEnabledEnvironmentSetting();
            IsDebugLoggingEnabled = envSetting;
        }

        public static void RedirectLogs(ILogSink logSink, out IReadOnlyDictionary<Type, ComponentGroupCompositionLogSink> redirectionLogSinks)
        {
            var redirectionSinks = new Dictionary<Type, ComponentGroupCompositionLogSink>();

            {
                Type loggerType = typeof(global::Datadog.Logging.Demo.Log);
                const string logComponentGroupMoniker = "LoggingDemo";

                if (logSink == null)
                {
                    redirectionSinks[loggerType] = null;
                    global::Datadog.Logging.Demo.Log.Configure.Error(null);
                    global::Datadog.Logging.Demo.Log.Configure.Info(null);
                    global::Datadog.Logging.Demo.Log.Configure.Debug(null);
                }
                else
                {
                    var redirectionLogSink = new ComponentGroupCompositionLogSink(logComponentGroupMoniker, logSink);
                    redirectionSinks[loggerType] = redirectionLogSink;
                    global::Datadog.Logging.Demo.Log.Configure.Error(redirectionLogSink.OnErrorLogEvent);
                    global::Datadog.Logging.Demo.Log.Configure.Info(redirectionLogSink.OnInfoLogEvent);
                    global::Datadog.Logging.Demo.Log.Configure.Debug(redirectionLogSink.OnDebugLogEvent);
                }

                Datadog.Logging.Demo.Log.Configure.DebugLoggingEnabled(IsDebugLoggingEnabled);
            }

            redirectionSinks.TrimExcess();
            redirectionLogSinks = redirectionSinks;
        }

        private static bool GetDebugLoggingEnabledEnvironmentSetting()
        {
            // Unless the debug log is explicitly disabled, we assume that it is enabled.
            try
            {
                string IsDebugLoggingEnabledEnvVarValue = ReadEnvironmentVariable(IsDebugLoggingEnabledEnvVarName);

                if (IsDebugLoggingEnabledEnvVarValue != null)
                {
                    if (IsDebugLoggingEnabledEnvVarValue.Equals("false", System.StringComparison.OrdinalIgnoreCase)
                            || IsDebugLoggingEnabledEnvVarValue.Equals("no", System.StringComparison.OrdinalIgnoreCase)
                            || IsDebugLoggingEnabledEnvVarValue.Equals("n", System.StringComparison.OrdinalIgnoreCase)
                            || IsDebugLoggingEnabledEnvVarValue.Equals("f", System.StringComparison.OrdinalIgnoreCase)
                            || IsDebugLoggingEnabledEnvVarValue.Equals("0", System.StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }
            catch
            { }
            
            return true;
        }

        private static string ReadEnvironmentVariable(string envVarName)
        {
            try
            {
                return Environment.GetEnvironmentVariable(envVarName);
            }
            catch
            {
                return null;
            }
        }
    }
}