using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Implementation;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main
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
            services.AddSwaggerGen  (c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "University", Version = "v1" });
            });
            #region CUSTOM SERVICES [D-I]
            services.AddScoped<IStudent_Service, Student_Service>();
            services.AddScoped<IGroup_Service, Group_Service>();
            services.AddScoped<IFaculty_Service, Faculty_Service>();
            services.AddScoped<ISpeciality_Service, Speciality_Service>();
            services.AddScoped<IAssessment_Service, Assessment_Service>();
            services.AddScoped<ISubject_Service, Subject_Service>();


            #endregion

            #region CORS
 

            
            services.AddCors(options =>
            {
                options.AddPolicy("angular",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "bruh v1"));
            }

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
