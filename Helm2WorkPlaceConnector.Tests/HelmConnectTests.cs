using HelmToWorkPlaceConnector.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Helm2WorkPlaceConnector.Tests
{
    [TestClass]
    public class HelmConnectTests
    {
        [TestMethod]
        public void TestGetAccountTypes()
        {
            var helmConnector = new HelmConnector("https://itb-sb.sandbox.helmconnect.com", "SqpQoe%2fk6xGBNgpG7MRFgnFVNFAzTXI1bEQyNlNjeEZraDB0");

            helmConnector.GetRequisitionLines("Confirmed");

        }
    }
}
