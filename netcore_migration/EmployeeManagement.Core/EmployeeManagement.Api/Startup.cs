using System;
using System.IO;
using System.Linq;
using System.Reflection;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using EmployeeManagement.Provider.Provider;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EmployeeManagement.Api
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
            services.AddSingleton<IConfigurationProvider<Employee>, EmployeeProvider>();
            services.AddSingleton<IConfigurationProvider<Project>, ProjectProvider>();
            services.AddSingleton<IConfigurationProvider<Department>, DepartmentProvider>();
            services.AddSingleton<IConfigurationProvider<Client>, ClientProvider>();
            services.AddSingleton<IConfigurationProvider<Skills>, SkillProvider>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "EmployeeManagementApi", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmployeeManagement.Api.xml"));
                c.ResolveConflictingActions(apidescription => apidescription.First());
                c.DescribeAllEnumsAsStrings();
            });
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediator, Mediator>();
            services.AddMediatorHandlers(typeof(Startup).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Managament Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }

    }
}
