using HelmToWorkPlaceConnector.Services.DataAccess;
using HelmToWorkPlaceConnector.Services.Models;
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
            var requisitionLines = helmConnector.GetRequisitionLines("");

            using (var db = new DataContext(connectionString))
            {
                foreach (var line in requisitionLines)
                {
                    //add if it doesn't exist
                    if (!db.RequisitionLines.Where(x => x.Id == line.Id).Any())
                    {
                        Log.Debug($"Adding Requisition line from Helm to database:{line.Id}.");

                        db.RequisitionLines.Add(line);
                    }

                }
                db.SaveChanges();

            }


            helmConnector.GetRequisitionLines("Confirmed");

        }

        public void ProcessUpdate()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

                var requisitionLine = new RequisitionLine()
                {
                    Id = new System.Guid("38FBC272-E8E4-11EB-8136-0A46ECC44582"),
                    Status = "Received On Shore"
                };

              //  await Task.Run(() => helmConnector.UpdateRequisitionLineAsync(requisitionLine));

               // helmConnector.UpdateRequisitionLineAsync(requisitionLine);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
