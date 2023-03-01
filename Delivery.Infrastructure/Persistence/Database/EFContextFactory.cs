using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Persistence.Database
{
    public class EFContextFactory : IDesignTimeDbContextFactory<EFContext>
    {
        public EFContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            optionsBuilder.UseSqlServer("data source=localhost; initial catalog=Delivery; integrated security=true; persist security info=true;TrustServerCertificate=True");

            return new EFContext(optionsBuilder.Options);
        }
    }
}
