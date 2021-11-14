using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        internal object currencies;

        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; } 
        public DbSet<Collor> Collors { get; set; }
        public object Product { get; internal set; }
        public object Colors { get; internal set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
