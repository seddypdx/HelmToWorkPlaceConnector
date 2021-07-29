using HelmToWorkPlaceConnector.Services.Models;
using HelmToWorkPlaceConnector.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Tests
{
    [TestClass]
    public class XMLUtilityTests
    {
        [TestMethod]
        public void TestSerializeToXML()
        {
            var req = new Requisition();

            req.Status = "HI";
            req.Created = DateTime.Now;
            req.Divisionid = new Guid();

            var result = XMLHelper.SerializeToXml(req);

            Assert.AreEqual("",result, "No String returned");

          

        }
    }
       
 }
