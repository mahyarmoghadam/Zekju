using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Zekju.Application.Flight.Dtos;
using Zekju.Application.Flight.QueryHandlers;
using Zekju.Utility;

namespace Zekju.App;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("// Project started.");
        var hostBuilder = App.CreateHostBuilder(args).Build();
        Console.WriteLine("// Creating a search request.");
        var searchRequest = SearchRequest.Create(args);
        Console.WriteLine($"// Validating the search model.");
        
        var mediator = hostBuilder.Services.GetService<IMediator>();
        var csvWriterService = hostBuilder.Services.GetService<ICsvWriterService>();

        Console.WriteLine("// Retrieving the mediator service.");
        
        var watch = new Stopwatch();
        watch.Start();
        Console.WriteLine("// Sending a search flights query to the mediator");
        var searchResponse = await mediator!.Send(new SearchFlightsQuery(searchRequest));
        watch.Stop();

        await csvWriterService!.WriteToCsvAsync(searchResponse, "result.csv");

        Console.WriteLine($"Search completed in {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine("Results written to result.csv.");

        await hostBuilder.RunAsync();
    }
}