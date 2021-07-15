using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.Models
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
