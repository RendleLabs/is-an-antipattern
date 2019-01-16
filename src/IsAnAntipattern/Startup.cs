using IsAnAntipattern.Metrics;
using IsAnAntipattern.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace IsAnAntipattern
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
            services.AddSingleton<IBlahBlahBlah, BlahBlahBlah>();
            services.AddSingleton<ISiteMetrics, SiteMetrics>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddMetrics();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    const int duration = 60 * 60 * 24;
                    context.Context.Response.Headers[HeaderNames.CacheControl] = $"public,max-age={duration}";
                }
            });

            app.UseMvc();
        }
    }
}
