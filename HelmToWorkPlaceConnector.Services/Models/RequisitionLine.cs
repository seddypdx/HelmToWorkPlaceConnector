using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace HelmToWorkPlaceConnector.Services.Models
{

    public enum ConnectorStatusEnum { New = 10, InWorkplace = 20, AssignedPO=30, POWrittenToHelm = 40, ModifiedByHelm= 50}

    public class UserDefinedField
    {
        public string key;
        public string value;
    }


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

        public Guid? PartId { get; set; }

        public string PartDescription { get; set; }

        public string PartNumber { get; set; }

        public string PartUnit { get; set; }

        public string PartCategory { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public string Assset { get; set; }

        public Guid CreatedById { get; set; }

        public User CreatedBy { get; set; }

        [NotMapped]
        public dynamic UserDefined { get; set; }


     
        public ConnectorStatusEnum ConnectorStatusId { get; set; }
        public ConnectorStatus ConnectorStatus { get; set; }

        public int? idfRQDetailKey { get; set; }

        public string PONumber { get; set; }

        public string Message { get; set; }
        public DateTime? LastUpdated { get; set; }

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

  
    public class RequisitionLineUpdateDataSuccess
    {
        public string ActionType{ get; set; }

        public Guid Id{ get; set; }
    }

    public class RequisitionLineUpdateDataFail
    {
        public IList<ErrorMsg> Data { get; set; }
    }

}
