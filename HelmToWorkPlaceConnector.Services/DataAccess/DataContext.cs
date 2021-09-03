using HelmToWorkPlaceConnector.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.DataAccess
{
    public class DataContext:DbContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString) : base()
        {
            this._connectionString = connectionString;
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<RequisitionLine> RequisitionLines { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<ConnectorStatus> ConnectorStatuses{ get; set; }
    }
}
