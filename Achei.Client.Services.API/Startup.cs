using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Achei.Client.Services.CrossCutting.IoC.Infra2;
using Achei.Client.Services.Application.Configurations;
using System;

namespace Achei.Client.Services.API {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
         
        public void ConfigureServices(IServiceCollection services) {

            services.AddMvcCore()
                .AddCors()
                .AddJsonFormatters()
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<AppConfiguration>(Configuration.GetSection(nameof(AppConfiguration)));

            services.AddResponseCompression();
            services.AddMemoryCache(opt => {
                opt.ExpirationScanFrequency = TimeSpan.FromSeconds(Configuration.GetSection(nameof(AppConfiguration)).Get<AppConfiguration>().ExpireTimeCacheSeconds);
            });

            ServicesDependency.AddServicesDependency(services, Configuration);  

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
