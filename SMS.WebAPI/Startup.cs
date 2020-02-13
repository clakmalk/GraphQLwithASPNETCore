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
            services.AddControllers();
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
            services.AddSingleton<ICourseRepository, MockCouseRepository>();
            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));
            services.AddTransient<StudentType>();
            services.AddTransient<CourseType>();

            services.AddScoped<ISchema,StudentSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                    .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseGraphQL<StudentSchema>();
            app.UseGraphiQLServer(new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions() { GraphiQLPath = "/api/graphiql" });
        }
    }
}
