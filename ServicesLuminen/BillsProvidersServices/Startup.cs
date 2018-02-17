using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillsProvidersServices.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BillsProvidersServices
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
            services.AddMvc();
            var connection = @"data source=40.121.222.138;initial catalog=BillsProvidersLuminen;persist security info=True;user id=dasuarez;password=Umng1131;MultipleActiveResultSets=True;";
            services.AddDbContext<BillsProvidersLuminenContext>(options => options.UseSqlServer(connection));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(corsPolicyBuilder => corsPolicyBuilder.WithOrigins("https://rentmepradma.azurewebsites.net").WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}
