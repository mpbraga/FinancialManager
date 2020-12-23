using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialManager.Data
{
    public class FinancialManagerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinancialManagerDbContext>
    {
        public FinancialManagerDbContext CreateDbContext(string[] args)
        {
            // TODO: implementar app settings
            var connectionString = "Data Source=localhost;Initial Catalog=FinancialManager;Persist Security Info=True;User ID=localdb;Password=db123;AllowUserVariables=True";

            var optionsBuilder = new DbContextOptionsBuilder<FinancialManagerDbContext>();

            optionsBuilder = (DbContextOptionsBuilder<FinancialManagerDbContext>)optionsBuilder
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            var dbContext = new FinancialManagerDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
