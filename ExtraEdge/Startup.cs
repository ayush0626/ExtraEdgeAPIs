using ExtraEdge.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExtraEdge.Models;
using ExtraEdge.Repository.Interfaces;
using ExtraEdge.Repository.Services;

namespace ExtraEdge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.AddAntiforgery();
            services.AddDbContext<MobileOwnerContext>(contextOptions =>
            {
                contextOptions.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });
            services.AddDbContext<LogDbContext>(contextOptions =>
            {
                contextOptions.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });
            services.AddHttpClient();
            services.AddLogging();
            services.AddHealthChecks();
            services.AddControllers();
            services.AddScoped<IMobileShopRepository<GeneratedReportModel>, MobileRepository>();
            services.AddScoped<IProfitReportRepository<ReportForProfit>, ProfitReportRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
