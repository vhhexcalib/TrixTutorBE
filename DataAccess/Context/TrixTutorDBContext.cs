using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TrixTutorDBContext : DbContext
    {
        public TrixTutorDBContext(DbContextOptions<TrixTutorDBContext> options) : base(options) 
        { 
        }

    }
}
