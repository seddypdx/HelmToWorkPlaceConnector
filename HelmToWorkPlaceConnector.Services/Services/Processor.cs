using HelmToWorkPlaceConnector.Services.DataAccess;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.Services
{
   public class Processor
    {
        IConfiguration _config;
        public Processor(IConfiguration config)
        {
            _config = config;
        }
        public void Process()
        {
            var apiKey = _config.GetValue<string>("APIKey");
            var connectionString = _config.GetValue<string>("ConnectionString");
            var basePath = _config.GetValue<string>("BasePath");

            Log.Debug($"Processing Process Requisitions against : {_config.GetValue<string>("ConnectionString")}");

            var helmConnector = new HelmConnector(basePath, apiKey);
            var requisitionLines = helmConnector.GetRequisitionLines("Confirmed");

            using (var db = new DataContext(connectionString))
            {
                foreach (var line in requisitionLines)
                {
                    //add if it doesn't exist
                    if (!db.RequisitionLines.Where(x => x.Id == line.Id).Any())
                    {
                        db.RequisitionLines.Add(line);
                    }

                }
                db.SaveChanges();

            }


            helmConnector.GetRequisitionLines("Confirmed");

        }
    }
}
