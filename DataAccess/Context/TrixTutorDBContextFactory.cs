using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TrixTutorDbContextFactory : IDesignTimeDbContextFactory<TrixTutorDBContext>
    {
        public TrixTutorDBContext CreateDbContext(string[] args)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var config = new ConfigurationBuilder()
                .SetBasePath(path + "\\TrixTutorAPI")
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TrixTutorDBContext>();
            var connectionString = config.GetConnectionString("MyDb");

            optionsBuilder.UseSqlServer(connectionString);

            return new TrixTutorDBContext(optionsBuilder.Options);
        }
    }
}
