using HelmToWorkPlaceConnector.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.DataAccess
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<RequisitionLine> RequisitionLines { get; set; }
    }
}
