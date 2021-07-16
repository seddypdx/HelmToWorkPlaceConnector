using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelmToWorkPlaceConnector.Services.DataAccess
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            return new DataContext("Server=(local);Database=HelmToWorkPlaceConnector;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


    }
}
