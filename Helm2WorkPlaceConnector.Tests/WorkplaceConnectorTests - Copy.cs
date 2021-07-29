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

            workPlaceConnector.TestCall();

        }
    }
       
 }
