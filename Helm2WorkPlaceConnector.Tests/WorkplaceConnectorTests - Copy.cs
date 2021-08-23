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
            var workPlaceConnector = new WorkPlaceConnector("http://test-app01.tbl.local/testworkplace");


            var requisitionLine = new RequisitionLine()
            {
                DueDate = new DateTime(2021, 8, 4),
                PartUnit = "EACH",
                Department = "2000",
                ShipToName = "MAIN",
                VendorName = "",
                VendorDocNumber = "",
                Project = "100-000", 
                CostCategory = "6202",
                Description = "SAE one",
                EstPrice = 30,
                Currency = "Z-C$"


            };

      


            workPlaceConnector.TestCall(requisitionLine);

        }
    }
       
 }
