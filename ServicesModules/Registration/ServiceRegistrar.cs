using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ServicesModules.Registration;

public static class ServiceRegistrar
{
    public static IServiceCollection AddServicesModules(this IServiceCollection services, Assembly assembly)
    {
        var moduleType = typeof(IServicesModule);

        var modules = assembly.DefinedTypes
            .Where(type => type is { IsInterface: false, IsAbstract: false }
                && moduleType.IsAssignableFrom(type))
            .Select(Activator.CreateInstance)
            .Cast<IServicesModule>();

        foreach (var module in modules)
        {
            module.Register(services);
        }

        return services;
    }
}

