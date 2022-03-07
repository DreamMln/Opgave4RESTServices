using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Excer1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// The AllowAnyOrigin could be replaced with WithOrigins which takes a string
        /// (or string array) of allowed domains to call our services.
        /// The AllowAnyMethod could be replaced with WithMethods which takes a string
        /// (or string array) of which HTTP methods are allowed.
        /// The AllowAnyHeader could be replaced with WithHeaders which takes a string
        /// (or string array) of which HTTP headers (not default) are allowed.
        /// Content-type could be one of these.
        /// </summary>
        /// <param name="services"></param>
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "v1" });
                
            //add xml
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            });

            //defined policies - CORS
            services.AddCors(options => options.AddPolicy("allowAllPolicies",
                builder => builder.AllowAnyOrigin()
                    .WithMethods("GET")
                    .AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Use swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger v1"));

            app.UseRouting();

            //Use defined CORS policies
            app.UseCors("allowAllPolicies");

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
