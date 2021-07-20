using HelmToWorkPlaceConnector;
using HelmToWorkPlaceConnector.Services.Services;
using Microsoft.Extensions.Configuration;

using Serilog;
using System;
using System.Diagnostics;
using System.IO;

namespace Helm2WorkPlaceConnector
{
    class Program
    {
        static void Main(string[] args)
        {
              IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddCommandLine(args)
               .Build();

            LogHandling.InitializeLogging(config);

            Log.Information("Starting HelmToWorkPlaceConnector");

            Process(config);

        }

    

        private static void Process(IConfiguration config)
        {
            try
            {
                var processor = new Processor(config);
                 //processor.Process();
                processor.ProcessUpdate();


            }
            catch (Exception ex)
            {
                Log.Error(ex, "Problems Processing Requisitions");

            }

        }
    }
}
