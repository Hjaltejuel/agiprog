using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Areas.Identity.Data
{
    public interface IDbContextFactory<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Generate a new <see cref="DbContext"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="TContext"/>.</returns>
        TContext CreateDbContext();
    }
}
