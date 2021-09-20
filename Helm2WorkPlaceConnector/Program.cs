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

            var processor = new Processor(config);

            ProcessConfirmedReqiusitions(processor);

            ProcessNewlyAddedRequisitionsToWorkplace(processor);

            ProcessRequisitionsAddedToAPo(processor);

        }

        private static void ProcessRequisitionsAddedToAPo(Processor processor)
        {
            try
            {
                processor.QueueWorkplaceLinesWithPO();
                processor.ProcessRequisitionsAddedToAPo();

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error on ProcessRequisitionsAddedToAPo");
            }
        }

  

        private static void ProcessNewlyAddedRequisitionsToWorkplace(Processor processor)
        {
            try
            {
                processor.ProcessNewlyAddedRequisitionsToWorkplace();

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error on ProcessNewlyAddedRequisitionsToWorkplace");
            }
        }

        private static void ProcessConfirmedReqiusitions(Processor processor)
        {
            try
            {
                processor.ProcessConfirmedRequisitions();

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error on ProcessConfirmedRequisitions");
            }
        }
    }
}
