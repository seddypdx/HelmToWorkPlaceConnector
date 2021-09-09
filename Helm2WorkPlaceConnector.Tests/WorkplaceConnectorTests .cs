using HelmToWorkPlaceConnector.Services.DataAccess;
using HelmToWorkPlaceConnector.Services.Models;
using HelmToWorkPlaceConnector.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Tests
{
    [TestClass]
    public class WorkplaceConnectorTests
    {
        [TestMethod]
        public void TestGetRequisitionLines()
        {

            var dbContext = new DataContext("Server=TEST-SQL01.TBL.LOCAL;Database=HelmToWorkPlaceConnector;uid=WPAPIUser;pwd=fg4K7T9QE9G;MultipleActiveResultSets=true");

            Guid id = new Guid("38FBC272-E8E4-11EB-8136-0A46ECC44582");

            var requisitionLine = dbContext.RequisitionLines.Find(id);

            var requisition = dbContext.Requisitions.Find(requisitionLine.RequisitionId);

            var workPlaceConnector = new WorkPlaceConnector();

            workPlaceConnector.AddRequisitionLine(dbContext,requisition, requisitionLine);

        }
    }
       
 }
