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
        private string _endPoint = "";


        public WorkPlaceConnector(string endPoint)
        {
            Log.Debug($"Initializing WorkplaceConnector {endPoint}");

            _endPoint = endPoint;
        }

    public static string TestRequisition()
        {
            string testXML = "<?xml version='1.0' encoding='UTF-8'?><Requisition CompanyDB='TWO' InterCompany=''><Header Action='' PassThroughLink='RQ1034'><edfCurrency/><edfDocumentID/><edfFacilityID/><edfFacilityIDFrom/><idfBlanketInvAmt/><idfBlanketInvPer/><idfComment/><idfCustAddr1/><idfCustAddr2/><idfCustAddr3/><idfCustAddr4/><idfCustAddr5/><idfCustAddr6/><idfCustAltPhone1/><idfCustAltPhone2/><idfCustAltPhoneExt1/><idfCustAltPhoneExt2/><idfCustAttention/><idfCustCity/><idfCustCountry/><idfCustEmail/> <idfCustFax/> <idfCustState/> <idfCustZipCode/> <idfDelegateNote/> <idfDescription/> <idfFlagBlanketInvAmtOverride/> <idfFlagKeepTogether/> <idfFlagProcessed/> <idfFlagSubmitted/> <idfLastLine/> <idfRQDate/> <idfRQHeaderKey/> <idfRQNumber/> <idfRQTypeKey/> <udfDateField01/> <udfDateField02/> <udfDateField03/> <udfDateField04/> <udfDateField05/> <udfLargeTextField01/> <udfLargeTextField02/> <udfLargeTextField03/> <udfNumericField01/> <udfNumericField02/> <udfNumericField03/> <udfNumericField04/> <udfNumericField05/> <udfNumericField06/> <udfNumericField07/> <udfNumericField08/> <udfNumericField09/> <udfNumericField10/> <udfTextField01/> <udfTextField02/> <udfTextField03/> <udfTextField04/> <udfTextField05/> <udfTextField06/> <udfTextField07/> <udfTextField08/> <udfTextField09/> <udfTextField10/> <vdfDeptID/> <vdfSecurityID/> <vdfWCSecurityDelegate/> <Detail Action='' PassThroughLink='LINE01'> <edfAnalysisGroup/> <edfBillTo/> <edfBuyer/>"
     + "<edfCurrency /> <edfDocumentID /> <edfDropShip /> <edfDropShipCustomer /> <edfENCBreakDown /> <edfENCGrantID /> <edfENCProjectID /> <edfENCUserDefined1 /> <edfENCUserDefined2 /> <edfENCUserDefined3 /> <edfENCUserDefined4 /> <edfENCUserDefined5 /> <edfENCUserDefined6 /> <edfENCUserDefined7 /> <edfFacilityID /> <edfFacilityIDFrom /> <edfGL /> <edfItem /> <edfItemDesc /> <edfLocation /> <edfLocationFrom /> <edfManuItem /> <edfPABudgetAuthCost /> <edfPABudgetAuthQty /> <edfPALineItemSeq /> <edfPAProjectL1 /> <edfPAProjectL2 /> <edfPAProjectL3 /> <edfPOLine /> <edfPONumber /> <edfPaymentTerm /> <edfPrice /> <edfPricePrec /> <edfShipMethod /> <edfShipTo /> <edfTranType /> <edfUOM /> <edfVendor /> <edfVendorAddrID /> <edfVendorDocNum /> <edfVendorItem /> <edfWSProductIndicator /> <idfBudgetApplyDate /> <idfCommentInternal /> <idfDatePromised /> <idfDateRequired /> <idfFlagBlanketPO /> <idfFlagManualDist /> <idfFlagVCOverride /> <idfLine />"
    + "<idfQty /> <idfQtyPrec /> <idfShipToAddr1 /> <idfShipToAddr2 /> <idfShipToAddr3 /> <idfShipToAltPhone1 /> <idfShipToAltPhone2 /> <idfShipToAltPhoneExt1 /> <idfShipToAltPhoneExt2 /> <idfShipToCity /> <idfShipToContact /> <idfShipToCountry /> <idfShipToFax /> <idfShipToName /> <idfShipToState /> <idfShipToZipCode /> <idfURLReference /> <idfVCOverrideNote /> <udfDateField01 /> <udfDateField02 /> <udfDateField03 /> <udfDateField04 /> <udfDateField05 /> <udfLargeTextField01 /> <udfLargeTextField02 /> <udfLargeTextField03 /> <udfNumericField01 /> <udfNumericField02 /> <udfNumericField03 /> <udfNumericField04 /> <udfNumericField05 /> <udfNumericField06 /> <udfNumericField07 /> <udfNumericField08 /> <udfNumericField09 /> <udfNumericField10 /> <udfTextField01 /> <udfTextField02 /> <udfTextField03 /> <udfTextField04 /> <udfTextField05 /> <udfTextField06 /> <udfTextField07 /> <udfTextField08 /> <udfTextField09 /> <udfTextField10 /> <vdfBudgetID /> <vdfBudgetValid /> <vdfComment /> <vdfContractID />"
    + "<vdfDeptID /><vdfGL /><vdfPriorityID /><vdfQtyCanceled /><vdfTaxScheduleID /></ Detail ></ Header ></ Requisition > ";

            return testXML;

        }

        public void TestCall()
        {

            var username = @"tbl\chrisw";
            var password = "5t7AmqnNnAiV";
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));
  
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(_endPoint + "/API/DIAPI_IN.aspx");
            objRequest.Headers.Add("Authorization", "Basic " + encoded);

            objRequest.Method = "POST";
            objRequest.KeepAlive = true;
            objRequest.UserAgent = "Paramount Technologies (Workplace)";
            objRequest.ContentType = "application/x-www-form-urlencoded";
            objRequest.Accept = "*/*";
            string strContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <Requisition CompanyDB=""ITB"">
                                <Header Action=""UP"" PassThroughLink=""MyTestID"">
                                <Detail Action=""UP"" PassThroughLink=""LINE01"">
                                <edfItemDesc>Widget Green</edfItemDesc>
                                <idfLine>1</idfLine>
                                <idfQty>23</idfQty>
                                </Detail>
                                 </Header>
                                </Requisition>
                                ";

            var xml = new XmlDocument();
            xml.LoadXml(strContent);
            var payload = HttpUtility.UrlEncode(xml.OuterXml);
            objRequest.ContentLength = payload.Length;
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(payload);
            myWriter.Close();
            // Make Call and get Response
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                string strResponse = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }

        }
    }
}
