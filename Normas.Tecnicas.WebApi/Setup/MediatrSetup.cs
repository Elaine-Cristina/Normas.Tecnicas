namespace Normas.Tecnicas.WebApi.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using MediatR;

    [ExcludeFromCodeCoverage]
    public static class MediatrSetup
    {
        public static IServiceCollection AddCustomMediatR(this IServiceCollection services)
        {
            var assemblies = new Assembly[] {
                AppDomain.CurrentDomain.Load("Normas.Tecnicas.Application"),
                AppDomain.CurrentDomain.Load("Normas.Tecnicas.Infrastructure"),
                AppDomain.CurrentDomain.Load("Normas.Tecnicas.WebApi")
            };

            services.AddMediatR(assemblies);
            return services;
        }
    }
}
