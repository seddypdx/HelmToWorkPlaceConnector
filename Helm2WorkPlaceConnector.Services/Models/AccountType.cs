using System;
using System.Collections.Generic;
using System.Text;

namespace Helm2WorkPlaceConnector.Services.Models
{
    public class AccountType
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsAgent { get; set; }
        public bool IsCompetitor { get; set; }
    }
}
