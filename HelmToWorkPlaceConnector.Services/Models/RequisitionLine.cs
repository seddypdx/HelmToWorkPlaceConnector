using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace HelmToWorkPlaceConnector.Services.Models
{

    public class UserDefinedField
    {
        public string key;
        public string value;
    }


    public class RequisitionLine
    {

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlIgnore]
        public DateTime Created { get; set; }

        [XmlElement(ElementName = "edfItemDesc")]
        public string Description { get; set; }

        [XmlIgnore]
        public string ExternalNumber { get; set; }

        [XmlIgnore]
        public Guid RequisitionId { get; set; }

        [XmlIgnore]
        public string Space { get; set; }

        [XmlElement(ElementName = "idfDateRequired")]
        public DateTime? DueDate { get; set; }

        [XmlIgnore]
        public string Priority { get; set; }

        [XmlElement(ElementName = "edfVendor")]
        public string VendorName { get; set; }

        [XmlElement(ElementName = "idfQuantity")]
        public decimal Quantity { get; set; }

        [XmlElement(ElementName = "edfPrice")]
        public decimal? EstPrice { get; set; }

        [XmlIgnore]
        public Guid PartId { get; set; }

        [XmlIgnore]
        public string PartDescription { get; set; }

        [XmlIgnore]
        public string PartNumber { get; set; }

        [XmlIgnore]
        public string PartUnit { get; set; }

        [XmlIgnore]
        public string PartCategory { get; set; }

        [XmlIgnore]
        public string Status { get; set; }

        [XmlIgnore]
        public string Type { get; set; }

        [XmlIgnore]
        public string Assset { get; set; }

        [XmlIgnore]
        public Guid CreatedById { get; set; }

        [XmlIgnore]
        public User CreatedBy { get; set; }

        [NotMapped]
        [XmlIgnore]
        public dynamic UserDefined { get; set; }


        [XmlElement(ElementName = "vdfDeptId")]
        [NotMapped]
        public string Department {get; set;}

        [XmlElement(ElementName = "idfShipToName")]
        [NotMapped]
        public string ShipToName { get; set; }


        [XmlElement(ElementName = "edfVendorDocNum")]
        [NotMapped]
        public string VendorDocNumber { get; set; }


        [XmlElement(ElementName = "edfENCProjectID")]
        [NotMapped]
        public string Project { get; set; }

        //[XmlElement(ElementName = "edfENCProjectID")]
        [NotMapped]
        public string CostCategory { get; set; }


        [XmlElement(ElementName = "edfCurrency")]
        [NotMapped]
        public string Currency { get; set; }

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
