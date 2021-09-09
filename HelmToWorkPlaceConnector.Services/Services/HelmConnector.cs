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


        /// <summary>
        /// Returns Requsition lines from all pages for the specified status
        /// If status is blank it will return all statuses
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IList<RequisitionLine> GetRequisitionLines(string status)
        {
            int page = 1;
            var returnLines = new List<RequisitionLine>();

            var pageLines = GetRequisitionLines(status, page);

            while (pageLines != null && pageLines.Any())
            {
                returnLines.AddRange(pageLines);

                page++;
                pageLines = GetRequisitionLines(status, page);
            }

            return returnLines;

         
        }

        public Requisition GetRequisition(Guid id)
        {
            Log.Debug($"Getting Requisition header for id:{id}");
            Requisition retRequisition = null;



            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{_endPoint}");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("API-Key", _apiKey);

                var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindRequisitions?page=1&Id={id}";
                //var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindRequisitions?page=1";


                Log.Debug($"Calling to get Requisitions {uri}");


                HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    var dataObjects = JsonConvert.DeserializeObject<RequisitionData>(jsonString);

                    try
                    {
                        foreach (var d in dataObjects.Data.Page)
                        {
                            Log.Debug($"Retreiving Requisition {d.Id}");
                            retRequisition = d;
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

            return retRequisition;
 

        }

        public IList<Requisition> GetRequisitionsByPage(int page)
        {
            Log.Debug($"Getting Requisition header for page:{page}");
            var retRequisitions = new List<Requisition>();



            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{_endPoint}");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("API-Key", _apiKey);

                var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindRequisitions?page={page}";


                Log.Debug($"Calling to get Requisitions {uri}");


                HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    var dataObjects = JsonConvert.DeserializeObject<RequisitionData>(jsonString);

                    try
                    {
                        foreach (var d in dataObjects.Data.Page)
                        {
                            Log.Debug($"Retreiving Requisition {d.Id}");
                            retRequisitions.Add(d);
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

            return retRequisitions;


        }


        public IList<RequisitionLine> GetRequisitionLines(string status, int page)
        {
            Log.Debug($"Getting Requisition lines for status:{status}, page:{page}");

            var returnLines = new List<RequisitionLine>();


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{_endPoint}");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("API-Key", _apiKey);

                var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindLineItems?page={page}";

                if (!string.IsNullOrEmpty(status))
                {
                    uri += $"&status={status}";
                }

                Log.Debug($"Calling to get Requisitions {uri}");

                HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    var dataObjects = JsonConvert.DeserializeObject<RequisitionLineData>(jsonString);

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

        public RequisitionLine GetRequisitionLine(Guid id)
        {
            Log.Debug($"Getting Requisition lines for id:{id}");

            RequisitionLine returnLine = null;


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{_endPoint}");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("API-Key", _apiKey);

                var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/FindLineItems?Page=1&Id={id}";

          

                Log.Debug($"Calling to get Requisitions Line item {uri}");

                HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    var dataObjects = JsonConvert.DeserializeObject<RequisitionLineData>(jsonString);
    
                    try
                    {
                        foreach (var d in dataObjects.Data.Page)
                        {
                            Log.Debug($"Retreiving Requisition Line {d.Id} of Requisition {d.RequisitionId}.");
                            Console.WriteLine("{0}", d.PartDescription);
                            returnLine = d;
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

            return returnLine;


        }



        public  void UpdateRequisitionLineStatus(Guid id, string status)
        {
            var requisitionLine = GetRequisitionLine(id);

            if (id == null)
                throw new Exception($"Cannot find Requisition Line {id} to update");

            requisitionLine.Status = status;
            UpdateRequisitionLineAsync(requisitionLine);

        }



        public void UpdateRequisitionLinePONumber(Guid id, string PONumber)
        {
            var requisitionLine = GetRequisitionLine(id);


            if (id == null)
                throw new Exception($"Cannot find Requisition Line {id} to update");


            requisitionLine.UserDefined.Workplaceponumber = PONumber;
            requisitionLine.Status = "Received On Shore";
            UpdateRequisitionLineAsync(requisitionLine);

        }


        private void UpdateRequisitionLineAsync(RequisitionLine requisitionLine)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{_endPoint}");
                client.Timeout = new TimeSpan(0, 2, 0);
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("API-Key", _apiKey);

                var uri = $"{_endPoint}/api/v1/hsqe/Requisitions/UpdateLineItem?UpdateInventory=true";

                Log.Debug($"Calling to update Requisitionline {uri}");

                //  HttpResponseMessage response = await client.PostAsJsonAsync(uri, requisitionLine);

                StringContent content = new StringContent(JsonConvert.SerializeObject(requisitionLine).ToString(), Encoding.UTF8, "application/json");

               HttpResponseMessage response = client.PostAsync(uri, content).Result;



                if (response.IsSuccessStatusCode)
                {

                    try
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;

                        try
                        {
                            var result = JsonConvert.DeserializeObject<RequisitionLineUpdateDataSuccess>(jsonString);
                            Log.Debug($"Sucessfully updatedRequisitionLine {requisitionLine.Id}, StatusCode:{requisitionLine.Status}. ");
                            return;

                        }
                        catch (Exception ex)
                        {
                            Log.Warning($"Error updating RequisitionLine try grabbing error json:{jsonString} / error {ex.Message}");
                            var failResult = JsonConvert.DeserializeObject<RequisitionLineUpdateDataFail>(jsonString);
                            foreach (var errMsg in failResult.Data)
                                Log.Error($"Error: {errMsg.Entity} : {errMsg.Message}");


                        }
         
      

                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex, $"Problems reading Update RequisitionLine Update ");
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

                    var jsonString = response.Content.ReadAsStringAsync().Result;

                    var failResult = JsonConvert.DeserializeObject<RequisitionLineUpdateDataFail>(jsonString);
                    if (failResult != null  && failResult.Data != null) {
                        foreach (var errMsg in failResult.Data)
                            Log.Error($"Error: {errMsg.Entity} : {errMsg.Message}");
                    }


                    throw new Exception($"Response:{response.StatusCode} / Response Phrase {response.ReasonPhrase}. Problems calling for Requisitions at {uri}.   ");
                }
            }
        }
    }
}
