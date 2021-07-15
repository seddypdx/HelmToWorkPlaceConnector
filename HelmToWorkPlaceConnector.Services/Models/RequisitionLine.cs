using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.Models
{



    public class RequisitionLine
    {

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string ExternalNumber { get; set; }
        public Guid RequisitionId { get; set; }
        public string Space { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
        public string VendorName { get; set; }

        public decimal Quantity { get; set; }
        public decimal? EstPrice { get; set; }
        public Guid PartIt { get; set; }
        public string PartDescription { get; set; }
        public string PartNumber { get; set; }
        public string PartUnit { get; set; }
        public string PartCategory { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Assset { get; set; }

        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public dynamic UserDefined { get; set; }


    }

    public class RequisitionLineResponse
    {
       public int TotalCount { get; set; }
       public IList<RequisitionLine> Page { get; set; }
    }

    public class RequisitionLineData
    {
        public RequisitionLineResponse Data { get; set; }
    }
}
