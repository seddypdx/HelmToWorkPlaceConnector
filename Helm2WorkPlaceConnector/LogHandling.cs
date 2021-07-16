using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector
{
    public static class LogHandling
    {

        public static void InitializeLogging(IConfiguration config)
        {
            var connectionString = config.GetValue<string>("ConnectionString");


            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("logs/HemlToWorkPlaceConnector.txt", rollingInterval: RollingInterval.Day)
               .WriteTo.File(new JsonFormatter(renderMessage: true), "logs/HelmToWorkplaceConnector.json")
               .WriteTo.MSSqlServer(connectionString,
                    sinkOptions: GetSinkOptions("Logs"),
                    columnOptions: GetColumnOptions())

              .CreateLogger();


        }

        private static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();


            return columnOptions;
        }


        private static SinkOptions GetSinkOptions(string name)
        {
            return new SinkOptions
            {
                TableName = name,
                AutoCreateSqlTable = true,
                BatchPostingLimit = 1
            };
        }
    }
}
