using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace iWillEstate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to ADD SERVICES to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

		// This method gets called by the runtime. Use this method to CONFIGURE the HTTP REQUEST PIPELINE.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
            
            string logging = "Logging";
            loggerFactory.AddConsole(Configuration.GetSection(logging));
			loggerFactory.AddDebug();

            // Redirect any non-API calls to the Angular application
            // so our application can handle the routing

			app.Use(async (context, next) =>
			{
                string indexHtmlPage = "/index.html";
                string apiString = "/api";
				await next();
				// If there’s no available file and the request doesn’t contain an extension, we’re probably trying to access a page.
				// Rewrite request to use app root
				if (context.Response.StatusCode == 404 && 
                    !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith(apiString))
				{
					context.Request.Path = indexHtmlPage;
					context.Response.StatusCode = 200; // Make sure we update the status code, otherwise it returns 404
					await next();
				}
			});

            // Configures application for usage as API
            // with default route of '/api/[Controller]'
            app.UseMvcWithDefaultRoute();

            // Configures application to serve the index.html file from /wwwroot
            // when you access the server from a web browser
			app.UseDefaultFiles();
			app.UseStaticFiles();
			//app.UseMvc();
		}
    }
}

