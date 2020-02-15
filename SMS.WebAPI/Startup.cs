using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SMS.WebAPI.Data;
using SMS.WebAPI.GraphQL.Schemas;
using SMS.WebAPI.GraphQL.Types.EntityTypes;
using SMS.WebAPI.Repositories;
using SMS.WebAPI.Repositories.Implementation;

namespace WebApplication1
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
            services.AddDbContext<SchoolDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IStudentRepository, SqlServerStudentRepository>();
            services.AddScoped<ICourseRepository, SqlServerCourseRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<SMS.WebAPI.GraphQL.Schemas.SchoolSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).
                AddMvcOptions( options => options.EnableEndpointRouting = false);

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseGraphQL<SchoolSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseMvc();
        }
    }
}
