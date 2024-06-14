using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ServicesModules;

public interface IAssemblyServiceModule
{
    void Register(IServiceCollection services, Assembly[] assemblies);
}