using System;
using agiprog.Areas.Identity.Data;
using agiprog.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(agiprog.Areas.Identity.IdentityHostingStartup))]
namespace agiprog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContextPool<agiprogContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("agiprogContextConnection")));

                services.AddDefaultIdentity<agiprogUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<agiprogContext>();
            });
        }
    }
}