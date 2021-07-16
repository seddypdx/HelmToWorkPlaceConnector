using HelmToWorkPlaceConnector.Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using Newtonsoft.Json;
using System.Linq;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace HelmToWorkPlaceConnector.Services.Services
{
    public class HelmConnector
    {
        private string _endPoint;
        private string _apiKey ;


        public HelmConnector(string endPoint, string apiKey)
        {
            Log.Debug($"Initializing HelmConnector {endPoint}");
            _endPoint = endPoint;
            _apiKey = apiKey;


        }

      

     


        public IList<RequisitionLine> GetRequisitionLines(string status)
        {
            var returnLines = new List<RequisitionLine>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{_endPoint}");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("API-Key", _apiKey);

                var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindLineItems?page=1";

                Log.Debug($"Calling to get Requisitions {uri}");

                HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsAsync<RequisitionLineData>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll

                    try
                    {
                        foreach (var d in dataObjects.Data.Page)
                        {
                            Log.Debug($"Retreiving Requisition Line {d.Id} of Requisition {d.RequisitionId}.");
                            Console.WriteLine("{0}", d.PartDescription);
                            returnLines.Add(d);
                        }

                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex, $"Problems reading Requisition Line ");
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    throw new Exception($"Response:{response.StatusCode} / Response Phrase {response.ReasonPhrase}. Problems calling for Requisitions at {uri}.   ");
                }

             }

            return returnLines;


        }





        //public async Task<AccountType> UpdateAccountTypeAsync(AccountType accountType)
        //{

        //    HttpClient client = new HttpClient();
        //    string path = new Uri($"{_endPoint}/AccountTypes").ToString();

        //  //  HttpResponseMessage response = await client.PutAsJsonAsync($"{path}/{accountType.Guid}", accountType);
        // //   response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //  //  accountType = await response.Content.ReadAsAsync<AccountType>();
        //    return accountType;
        //}
    }
}
