using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using agiprog.Data;
using Blazored.Toast;
using agiprog.Areas.Identity.Data;

namespace agiprog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<agiprogContext>(options => options.UseMySql(
                 Configuration.GetConnectionString("agiprogContextConnection")).UseLazyLoadingProxies());

            services.AddScoped<agiprogContext>(p => p.GetRequiredService<IDbContextFactory<agiprogContext>>().CreateDbContext());

            services.AddDefaultIdentity<agiprogUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<agiprogContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<MeetingService>();
            services.AddScoped<MessageService>();
            services.AddScoped<StepService>();
            services.AddScoped<RoadmapService>();
            services.AddScoped<HubService>();
            services.AddBlazoredToast();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
            });
        }
    }
}
