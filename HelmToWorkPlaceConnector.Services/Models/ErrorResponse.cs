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

    public class ErrorMsg
    {
        public string Entity { get; set; }
        public string Message { get; set; }
    }
}
