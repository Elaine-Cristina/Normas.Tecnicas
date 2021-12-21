namespace Normas.Tecnicas.WebApi.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
    using Normas.Tecnicas.Infrastructure.Repository;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterDependencyInjectionContainer(this IServiceCollection services)
        {
            services.AddScoped<INormasTecnicasRepository, NormasTecnicasRepository>();

            return services;
        }
    }
}
