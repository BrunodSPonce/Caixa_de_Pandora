using Microsoft.Extensions.DependencyInjection;
using Unidas.Inventario.Application.Interfaces;
using Unidas.Inventario.Application.Services;
using Unidas.Inventario.Domain;
using Unidas.Inventario.Domain.Interfaces.ExternalServices;
using Unidas.Inventario.Domain.Interfaces.Repositories;
using Unidas.Inventario.Domain.Interfaces.Services;
using Unidas.Inventario.Domain.Services;
using Unidas.Inventario.Infra.Data.Repositories;
using Unidas.Inventario.Infra.ExternalServices;

namespace Unidas.Inventario.Infra.CrossCutting.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEquipamentoService, EquipamentoService>();



            services.AddScoped<IAcessoAppService, AcessoAppService>();
            services.AddScoped<IEquipamentoAppService, EquipamentoAppService>();


            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
        

            services.AddScoped<IAcessoService, AutenticacaoExternalService>();
        }
    }
}
