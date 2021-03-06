using System;
using System.Collections.Generic;
using System.Text;

namespace Helm2WorkPlaceConnector.Services.Models
{


    public class Requisition
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DueDate { get; set; }
        public string Name { get; set; }
        public string Space { get; set; }
        public string Priority { get; set; }
        public string ExternalNumber { get; set; }
        public int LineItemCount { get; set; }
        public string Status { get; set; }
        public Guid Divisionid { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string Assset { get; set; }
        public decimal EstCost { get; set; }
        public decimal LinkedItemType { get; set; }
        public Guid LinkedItemid { get; set; }
        public dynamic UserDefined { get; set; }
    }

    public class RequisitionResponse
    {
       public int TotalCount { get; set; }
       public IList<Requisition> Page { get; set; }
    }

    public class RequisitionData
    {
        public RequisitionResponse Data { get; set; }
    }
}
