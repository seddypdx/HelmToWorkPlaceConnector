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
        public void ProcessConfirmedRequisitions()
        {
            var apiKey = _config.GetValue<string>("APIKey");
            var connectionString = _config.GetValue<string>("ConnectionString");
            var basePath = _config.GetValue<string>("BasePath");

            Log.Debug($"Processing Process Requisitions against : {_config.GetValue<string>("ConnectionString")}");

            var helmConnector = new HelmConnector(basePath, apiKey);
            var requisitionLines = helmConnector.GetRequisitionLines("Confirmed");
            //var requisitionLines = helmConnector.GetRequisitionLines("");


            using (var db = new DataContext(connectionString))
            {
                foreach (var line in requisitionLines)
                {
                    try
                    {
                        ProcessLineToDatabase(helmConnector, db, line);
                    }
                    catch(Exception ex)
                    {
                        Log.Error(ex, $"Could not process RequisitionLine :{line.Id}");
                    }
                }

            }


            //helmConnector.GetRequisitionLines("Confirmed");

        }

        private static void ProcessLineToDatabase(HelmConnector helmConnector, DataContext db, RequisitionLine line)
        {
            //add if it doesn't exist
            if (!db.RequisitionLines.Where(x => x.Id == line.Id).Any())
            {
                Log.Debug($"Adding Requisition line from Helm to database:{line.Id}.");
                line.ConnectorStatusId = ConnectorStatusEnum.New;
                line.Message = "Initialized in Database.";
                line.LastUpdated = DateTime.Now;
                db.RequisitionLines.Add(line);

                if (!db.Requisitions.Where(x => x.Id == line.RequisitionId).Any())
                {
                    var requisition = helmConnector.GetRequisition(line.RequisitionId);
                    if (requisition != null)
                    {
                        db.Requisitions.Add(requisition);
                    }
                }

                db.SaveChanges(); // save changes after each line in case we have errors


            }
        }


        /// <summary>
        /// This take all Requisition lInes in status 10 (new) and write them to workplace
        /// </summary>
        public void ProcessNewlyAddedRequisitionsToWorkplace()
        {
            try
            {
                var connectionString = _config.GetValue<string>("ConnectionString");
                var workPlaceConnector = new WorkPlaceConnector();


                Log.Debug($"Processing New Requisitions into workplace");



                using (var db = new DataContext(connectionString))
                {
                    var lines = db.RequisitionLines.Where(x => x.ConnectorStatusId == ConnectorStatusEnum.New).ToList();

                    foreach (var line in lines)
                    {
                        try
                        {
                            Log.Debug($"Adding Requisition {line.Id} to Workpalce");
                            var requisition = db.Requisitions.Find(line.RequisitionId);
                            workPlaceConnector.AddRequisitionLine(db, requisition, line);

                            line.ConnectorStatusId = ConnectorStatusEnum.InWorkplace;
                            line.Message = "Added to Workplace.";
                            line.LastUpdated = DateTime.Now;
                            db.SaveChanges();

                            Log.Debug($"Helm LineId {line.Id} Connected to  Workplace Id {line.idfRQDetailKey}");


                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, $"Processing line {line.RequisitionId}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, $"Processing RequisitionLines");

                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Call this to find all Requisitions in Workplace that have been assigned PO's and need to be sent
        /// back to Helm
        /// </summary>
        public void QueueWorkplaceLinesWithPO()
        {
            Log.Debug($"Queuing Po's that need to be sent over to workplace");

            var connectionString = _config.GetValue<string>("ConnectionString");

            using (var db = new DataContext(connectionString))
            {

                var workplaceConnector = new WorkPlaceConnector();
                workplaceConnector.QueueRequisitionLinesToSendPO(db);
            }


        }

        /// <summary>
        /// This will find Requisision lines that have been assigned po's and not written back to helm
        /// It will write the po number to helm, and set the requitiotion line in helm to received on shore
        /// and it will update the Requistion line connection status to POUpdtedToHelm
        /// </summary>
        public void ProcessRequisitionsAddedToAPo()
        {
            try
            {
                var apiKey = _config.GetValue<string>("APIKey");
                var basePath = _config.GetValue<string>("BasePath");
                var connectionString = _config.GetValue<string>("ConnectionString");


                Log.Debug($"Processing Requisitions that have been assigned a PI in workplace");

                var helmConnector = new HelmConnector(basePath, apiKey);


                using (var db = new DataContext(connectionString))
                {
                    var lines = db.RequisitionLines.Where(x => x.ConnectorStatusId == ConnectorStatusEnum.AssignedPO).ToList();

                    foreach (var line in lines)
                    {
                        try
                        {
                            Log.Debug($"Writing PO {line.PONumber} back to Helm for RequisitionLine {line.Id}");
                            helmConnector.UpdateRequisitionLinePONumber(line.Id, line.PONumber);
                            line.ConnectorStatusId = ConnectorStatusEnum.POWrittenToHelm;
                            line.Message = "PONumber sent to Helm";
                            line.LastUpdated = DateTime.Now;

                            db.SaveChanges();

                        }
                        catch(Exception ex)
                        {
                            Log.Error(ex, $"ProcessRequisitionsAddedToAPo");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, $"Processing RequisitionLines");

                Console.WriteLine(ex.Message);
            }
        }
    }
}
