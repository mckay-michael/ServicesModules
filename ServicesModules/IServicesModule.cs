using Microsoft.Extensions.DependencyInjection;

namespace ServicesModules;

public interface IServicesModule
{
    void Register(IServiceCollection services);
}