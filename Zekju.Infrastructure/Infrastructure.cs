using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Zekju.Infrastructure;

public static class Infrastructure
{ 
    public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DataContextConnection");
        services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}