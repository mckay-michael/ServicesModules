using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServicesModules;

public interface IConfigurationServicesModule
{
    void Register(IServiceCollection services, ConfigurationManager configuration);
}