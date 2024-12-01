using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public static class DbContextConnection 
    {
        public static IServiceCollection AddTrixTutorDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TrixTutorDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
