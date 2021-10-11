using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Book_Rest_API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Items API", Version = "v1.0" });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ItemRestAPI", Version = "v1", Description = "Learning about APIs v1!", Contact = new OpenApiContact { Name = "Sarah", Email = "sbaek18@gmail.com" } });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "ItemRestAPI", Version = "v2", Description = "Learning about APIs v2!", Contact = new OpenApiContact { Name = "Sarah", Email = "sbaek18@gmail.com" } });
            });
            services.AddCors(options => options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(30))));

            services.AddCors(options => options.AddPolicy("AllowOnlyGet",
                builder => builder.AllowAnyOrigin().WithMethods("GET").AllowAnyHeader()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(30))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API v1.0")

            //);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItemRestAPI v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "ItemRestAPI v2");
            });
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
