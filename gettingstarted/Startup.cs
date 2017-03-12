using gettingstarted.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace gettingstarted
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
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
			services.AddSingleton<IGettingStartedRepo, GettingStartedRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			var logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.RollingFile("Log/gettingstarted-{Date}.log")
				.CreateLogger();
			
			loggerFactory.AddConsole(Configuration.GetSection("Logging"))
            	.AddDebug()
				.AddSerilog(logger);

			app.UseDefaultFiles();
			app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
