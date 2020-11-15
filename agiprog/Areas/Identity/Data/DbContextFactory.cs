using agiprog.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Areas.Identity.Data
{
    public class DbContextFactory<TContext>
        : IDbContextFactory<TContext> where TContext : DbContext
    {
        private readonly IServiceProvider provider;

        public DbContextFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public TContext CreateDbContext()
        {
            if (provider == null)
            {
                throw new InvalidOperationException(
                    $"You must configure an instance of IServiceProvider");
            }

            return ActivatorUtilities.CreateInstance<TContext>(provider);
        }
    }
}
