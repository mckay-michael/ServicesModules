using System;

namespace ServicesModules.Example;

public class TestServiceModule : IServicesModule
{
    public void Register(IServiceCollection services)
    {
        Console.WriteLine("TestServiceModule was registered");
    }
}

