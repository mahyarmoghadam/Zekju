using Microsoft.Extensions.DependencyInjection;

namespace Zekju.Utility;

public static class Utility
{ 
    public static IServiceCollection AddUtility(this IServiceCollection services)
    {
        services.AddScoped<ICsvWriterService, CsvWriterService>();

        return services;
    }
}