using HelmToWorkPlaceConnector.Services.DataAccess;
using HelmToWorkPlaceConnector.Services.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace HelmToWorkPlaceConnector.Services.Services
{
    //http://localhost/workplace/api/diapi_in.aspx, t
    //5t7AmqnNnQiV

    public class WorkPlaceConnector
    {


        public WorkPlaceConnector()
        {
            Log.Debug($"Initializing WorkplaceConnector");

        }

  
        public void AddRequisitionLine(DataContext dbContext, Requisition requisition,  RequisitionLine requisitionLine)
        {
            Log.Debug($"Adding Requisition Line ID: {requisitionLine.Id}");

            dbContext.Database.ExecuteSqlRaw("h2w_RequisitionUpdate @p0", parameters: new[] { requisitionLine.Id.ToString() });

            // after we call this sproc we need to update requisition and requisisiont line to get the 
            // reference columns updated

            dbContext.Entry(requisition).Reload();
            dbContext.Entry(requisitionLine).Reload();


        }

        public void QueueRequisitionLinesToSendPO(DataContext dbContext)
        {
            Log.Debug($"Calling RequisitionLiens to be queued");

            dbContext.Database.ExecuteSqlRaw("h2w_RequisitionLineQueuePOs ");

            // after we call this sproc we need to update requisition and requisisiont line to get the 
            // reference columns updated


        }
    }
}
