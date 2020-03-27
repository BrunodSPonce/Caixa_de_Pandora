using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.Collections.Generic;
using Unidas.Base.Infra.CrossCutting.Enum;
using Unidas.Base.Servicos.Api.Configurations;
using Unidas.Inventario.Infra.CrossCutting.IoC;

namespace Unidas.Inventario.Servicos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);


            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigurarApiUnidas(
                   Configuration,
                   PlatformServices.Default.Application.ApplicationBasePath,
                   PlatformServices.Default.Application.ApplicationName,
                   new List<string>() { "v1" },
                   null,
                   new MappingProfile());

            Injector.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigurarApiUnidas(
                     Contexto.Outros,
                     new List<string>() { "v1" }); 
        }
    }
}
