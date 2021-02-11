using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AdApi.GraphObject.Mutations;
using AdApi.GraphObject.Queries;
using AdApi.GraphObject.Queries.DataLoaders;
using AdApi.GraphObject.Queries.Types.Ads;
using AdApi.GraphObject.Queries.Types.Metrics;
using AdApplication.EntityFrameworkDataAccess;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            WebHostEnvironment = environment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // Database services
            services.AddEntityFrameworkSqlServer();

            services.AddPooledDbContextFactory<AdDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"), sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            10,
                            TimeSpan.FromSeconds(30),
                            null);
                    });

                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            })
                .AddDbContext<AdDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"), sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            10,
                            TimeSpan.FromSeconds(30),
                            null);
                    });

                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });

            services.AddGraphQLServer()
                .AddType<AdObjectType>()
                .AddType<CategoryObjectType>()
                .AddType<MetricObjectType>()
                .AddQueryType<QueryType>()
                .AddMutationType<AdMutationsType>()
                .AddDataLoader<CategoryByIdDataLoader>()
                .AddDataLoader<MetricByIdDataLoader>()
                .AddDataLoader<AdByIdDataLoader>()
                .AddProjections()
                .AddFiltering();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });

                endpoints.MapGraphQL().WithOptions(new GraphQLServerOptions
                {
                    Tool = { Enable = true }
                });
            });
        }
    }
}