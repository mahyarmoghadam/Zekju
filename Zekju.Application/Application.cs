using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zekju.Infrastructure;

namespace Zekju.Application;

public static class Application
{ 
    public static IServiceCollection AddApplication(this IServiceCollection services)
    { 
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Application).Assembly));

        return services;
    }
}