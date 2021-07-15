using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.Models
{
    public class LocationType
    {
        public string Id { get; set; }
        public string Name { get; set; }
      }

    public class LocationRequestResult
    {
        public IList<LocationType> Results { get; set; }
        public int Page { get; set; }
        public string Next { get; set; }

    }

    public class LocationData
    {
        public LocationRequestResult Data { get; set; }
    }
}
