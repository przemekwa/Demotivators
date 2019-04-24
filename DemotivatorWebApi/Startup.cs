using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemotivatorApi.Interface;
using DemotivatorWebApi.ControllersLogic;
using JbzdyApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DemotivatorWebApi
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IDemotivatorApi, DemotivatorApi.DemotivatorApi>(sp => new DemotivatorApi.DemotivatorApi("http://demotywatory.pl/"));
            services.AddScoped<IDemotivatorsLogic, DemotivatorsLogic>();

            services.AddScoped<IJbzdyApi, JbzdyApi.JbzdyApi>(sp=>new  JbzdyApi.JbzdyApi("https://jbzdy.pl/"));
            services.AddScoped<IJbzdyLogic, JbzdyLogic>();

            services.AddScoped<IFavouriteLogic, FavouriteLogic>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            

            app.UseMvc();




        }
    }
}
