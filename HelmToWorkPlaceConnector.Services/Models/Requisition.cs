using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace HelmToWorkPlaceConnector.Services.Models
{

 

    public class Requisition
    {
        public Guid Id { get; set; }

        [XmlElement(ElementName = "sdfCreated")]
        public DateTime Created { get; set; }

        [XmlElement(ElementName = "idfRQDate")]
        public DateTime? DueDate { get; set; }
        [XmlIgnore]
        public string Name { get; set; }
        [XmlIgnore]
        public string Space { get; set; }
        [XmlIgnore]
        public string Priority { get; set; }
        [XmlIgnore]
        public string ExternalNumber { get; set; }
        [XmlIgnore]
        public int LineItemCount { get; set; }
        [XmlIgnore]
        public string Status { get; set; }

        [XmlIgnore]
        public Guid Divisionid { get; set; }

        [XmlIgnore]
        public Guid CreatedById { get; set; }

        [XmlIgnore]
        public User CreatedBy { get; set; }
        [XmlIgnore]
        public string Assset { get; set; }
        [XmlIgnore]
        public decimal EstCost { get; set; }
        [XmlIgnore]
        public decimal? LinkedItemType { get; set; }
        [XmlIgnore]
        public Guid? LinkedItemid { get; set; }

        public int? idfRQHeaderKey { get; set; }

        public string idfRQNumber { get; set; }

        [XmlIgnore]
        [NotMapped]
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
