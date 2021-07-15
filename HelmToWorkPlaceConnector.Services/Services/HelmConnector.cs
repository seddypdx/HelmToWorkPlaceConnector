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

namespace HelmToWorkPlaceConnector.Services.Services
{
    public class HelmConnector
    {
        private string _endPoint;
        private string _apiKey ;

        public HelmConnector(string endPoint, string apiKey)
        {
            _endPoint = endPoint;
            _apiKey = apiKey;

        }

      

     


        public void GetRequisitionLines(string status)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{_endPoint}");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("API-Key", _apiKey);
            //  client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            //  var uri = new Uri($"{_endPoint}/companies/{controller}?page=1").ToString();
            //  var uri = "https://itb-sb.sandbox.helmconnect.com/api/v1/jobs/companies/FindCompanies?page=1&IsAP=true";
            //   var uri = "https://itb-sb.sandbox.helmconnect.com/api/v2/public/locations";
            //var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindLineItems?page=1&status={status}";
            var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindLineItems?page=1";


            // var request = new HttpRequestMessage(HttpMethod.Get, controller);
            // request.Content = new StringContent("", Encoding.UTF8, "applicatoin/json");
            // List data response.
            HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
           // HttpResponseMessage response = client.SendAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                // Parse the response body.
                // var dataObjects = response.Content.ReadAsAsync<IEnumerable<LocationRequestResult>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                var dataObjects = JsonConvert.DeserializeObject<RequisitionLineData>(jsonString);


                foreach (var d in dataObjects.Data.Page)
                {
                    Console.WriteLine("{0}", d.PartDescription);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
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
