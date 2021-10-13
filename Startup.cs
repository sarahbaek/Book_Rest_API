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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookRestAPI", Version = "v1", Description = "Learning about APIs v1!", Contact = new OpenApiContact { Name = "Sarah", Email = "sbaek18@gmail.com" } });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "BookRestAPI", Version = "v2", Description = "Learning about APIs v2!", Contact = new OpenApiContact { Name = "Sarah", Email = "sbaek18@gmail.com" } });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookRestAPI v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "BookRestAPI v2");
            });
            app.UseRouting();
            //app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
