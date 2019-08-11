using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.Cache;
using ocelotteste.Tools.Cache;
using ocelotteste.Tools.Handler;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace ocelotteste
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOcelot(Configuration)
                    .AddCacheManager(x =>
                        {
                            x.WithDictionaryHandle();
                        })
                    .AddDelegatingHandler<BusSecurtityHandler>();

            services.AddSingleton<IOcelotCache<CachedResponse>, RedisCache>();

            services.AddHttpClient("barramento", client =>
            {
                client.BaseAddress = new System.Uri("endereco barramento");
            }
            ).ConfigureHttpMessageHandlerBuilder(config =>
            {
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseOcelot().Wait();
        }
    }
}
