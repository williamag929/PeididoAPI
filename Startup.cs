using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PedidoApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();


        Console.WriteLine($"option1 = {Configuration["option1"]}");
        Console.WriteLine($"option2 = {Configuration["option2"]}");
        Console.WriteLine($"constr = {Configuration["constr"]}");
        Console.WriteLine();


        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

        // Adds services required for using options.
        services.AddOptions();

        // Register the IConfiguration instance which MyOptions binds against.
        services.Configure<Models.MyOptions>(Configuration);

            // Add framework services.
            services.AddMvc();
            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

             // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:8100")
            .AllowAnyHeader()
            .AllowAnyMethod());

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
