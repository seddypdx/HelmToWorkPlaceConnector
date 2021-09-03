using HelmToWorkPlaceConnector.Services.Models;
using HelmToWorkPlaceConnector.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Helm2WorkPlaceConnector.Tests
{
    [TestClass]
    public class HelmConnectTests
    {
        [TestMethod]
        public void TestGetRequisitionLines()
        {
            var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

            helmConnector.GetRequisitionLines("Confirmed");

        }

        [TestMethod]
        public void TestUpdateRequisitioLine()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

                var id = new System.Guid("38FBC272-E8E4-11EB-8136-0A46ECC44582");
                 helmConnector.UpdateRequisitionLineStatus(id, "Confirmed");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestUpdatePONumberLine()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

                var id = new System.Guid("38FBC272-E8E4-11EB-8136-0A46ECC44582");
                helmConnector.UpdateRequisitionLinePONumber(id, "POUpdatedTHis");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        [TestMethod]
        public void TestUpdateRequisitioLineFail()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

                var id = new System.Guid("38FBC272-E8E4-11EB-8136-0A46ECC44582");
                helmConnector.UpdateRequisitionLineStatus(id, "junk");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void TestGetRequisitioLine()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

                var id = new System.Guid("eb3cc909-0460-11ec-8136-0a46ecc44582");
                 var line = helmConnector.GetRequisitionLine(id);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestGetRequisition()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

                var id = new System.Guid("41d015b9-b2f8-11e9-8250-ec335919b4ac");
                var req = helmConnector.GetRequisition(id);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestGetRequisitionPage()
        {
            try
            {
                var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

            
                var req = helmConnector.GetRequisitionsByPage(1);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
