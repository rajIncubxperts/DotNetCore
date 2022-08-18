using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Non_GenericTask.Data;
using Non_GenericTask.Repository;
using Non_GenericTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Non_GenericTask
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
            //For Entity FrameWork
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Database"))); //Add  
           //services.AddTransient<IStudent, StudentImplantation>(); //Every request it will created the object. 
            //services.AddSingleton<IStudent, StudentImplantation>(); //For Multiple request across the appl one object is created.(It will go in the constructor onetime only) 
            services.AddScoped<IStudent, StudentImplantation>(); //One Object for request. Send email and your succssfully register for 2 email in this case service needeed 2 times Inject one time but scope use two times so it will not create 2 objects One object share for both 
            //services.AddScoped(typeof(IStudent<>), typeof(StudentImplantation<>)); 
            //In which senario which DI type you will used?
            //Actually, its dependence on senario If i want one object in the over all application then i will
            //go for the singleton and If wanted object for every requets will go for Tarnsient.
            //every requets means Security.

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Non_GenericTask", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Non_GenericTask v1"));
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
