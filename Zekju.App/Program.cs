using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Zekju.Application.Flight.Dtos;
using Zekju.Application.Flight.QueryHandlers;

namespace Zekju.App;

public class Program
{
    static async Task Main(string[] args)
    {
        var hostBuilder = App.CreateHostBuilder(args).Build();
        var searchRequest = SearchRequest.Create(args);

        var mediator = hostBuilder.Services.GetService<IMediator>();
        var searchResponse = await mediator!.Send(new SearchFlightsQuery(searchRequest));

        await hostBuilder.RunAsync();
    }
}