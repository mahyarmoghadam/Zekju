
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Zekju.Application;
using Zekju.Infrastructure;

namespace Zekju.App;

public static class App
{
    private const string FileName = "appsettings.json";
    private static IConfigurationRoot _configuration = null!;

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((configure) =>
            {
                configure.AddJsonFile(FileName, true, true);
                _configuration = configure.Build();
            })
            .ConfigureServices((services) =>
            {
                services.AddDataContext(_configuration)
                        .AddApplication();
            });
    }
}