﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using contact_app.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization; 

namespace contact_app
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
            // services.AddDbContext<ContactAppContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("ContactDb")));
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddDbContext<ContactAppContext>(db => db.UseSqlServer(Configuration.GetConnectionString("ContactDb")));
            services
            .AddMvc()
            .AddJsonOptions(options => {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c=> c.AllowAnyHeader()
            .AllowAnyMethod().AllowAnyOrigin()
            .AllowCredentials());
            app.UseMvc();

            //Redirect non api calls to angular app that will handle routing of the app. 
            // app.Use(async (context, next) =>
            // {
            //     await next();
            //     if (context.Response.StatusCode == 404 &&
            //       / !Path.HasExtension(context.Request.Path.Value) &&
            //       / !context.Request.Path.Value.StartsWith("/api/"))
            //     {
            //         context.Request.Path = "/index.html";
            //         await next();
            //     }
            // });

           // configure the app to serve index.html from /wwwroot folder
          //  app.UseDefaultFiles();
          //  app.UseStaticFiles();

            // configure the app for usage as api
          //  app.UseMvcWithDefaultRoute();
    }
}
}
