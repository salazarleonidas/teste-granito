using AutoMapper;
using Domain.Http.Interfaces;
using Domain.Services.DomainServices;
using Domain.Services.Interfaces;
using Domain.Shared.AutoMapper;
using Http;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class Boostrap
    {
        public static void Inicializar(IServiceCollection services)
        {
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());

            services.AddScoped<IDomainService, DomainService>();
            services.AddScoped<IHttpTaxas, HttpTaxas>();
        }
    }
}