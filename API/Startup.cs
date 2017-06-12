using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Repository;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace API
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
		public IContainer ApplicationContainer { get; private set; }

		//public IConfigurationRoot Configuration { get; private set; }
		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		//public void ConfigureServices(IServiceCollection services)
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
            // Add framework services.
            services.AddMvc();

			// Create the container builder.
			var builder = new ContainerBuilder();
			builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
			builder.Populate(services);
			this.ApplicationContainer = builder.Build();

			// Create the IServiceProvider based on the container.
			return new AutofacServiceProvider(this.ApplicationContainer);
		}

		// Configure is where you add middleware. This is called after
		// ConfigureServices. You can use IApplicationBuilder.ApplicationServices
		// here if you need to resolve things from the container.
		public void Configure(
		  IApplicationBuilder app,
		  ILoggerFactory loggerFactory,
		  IApplicationLifetime appLifetime)
		{
			loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			app.UseMvc();

			// If you want to dispose of resources that have been resolved in the
			// application container, register for the "ApplicationStopped" event.
			appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
		}
	}
}
