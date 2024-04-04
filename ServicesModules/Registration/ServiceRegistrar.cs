using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ServicesModules.Registration;

public static class ServiceRegistrar
{
    public static IServiceCollection AddServicesModules(this IServiceCollection services, ConfigurationManager configuration, params Assembly[] assemblies)
    {
        var servicesType = typeof(IServicesModule);
        var configurationServicesModule = typeof(IConfigurationServicesModule);
        
        var definedTypes = assemblies.SelectMany(assembly => assembly.DefinedTypes);

        foreach (var type in definedTypes)
        {
            if (type is not { IsInterface: false, IsAbstract: false })
            {
                continue;
            }

            if (servicesType.IsAssignableFrom(type))
            {
                var servicesModel = (IServicesModule)Activator.CreateInstance(type);
                servicesModel.Register(services);
            }

            if (configurationServicesModule.IsAssignableFrom(type))
            {
                var servicesModel = (IConfigurationServicesModule)Activator.CreateInstance(type);
                servicesModel.Register(services, configuration);
            }
        }

        return services;
    }
}

