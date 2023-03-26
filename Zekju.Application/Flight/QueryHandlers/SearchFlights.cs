using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Zekju.Application.Flight.Dtos;
using Zekju.Infrastructure;

namespace Zekju.Application.Flight.QueryHandlers;

public sealed record SearchFlightsQuery(SearchRequest SearchRequest) : IRequest<IList<SearchResponse>>
{
}

public class SearchFlightsQueryHandler : IRequestHandler<SearchFlightsQuery, IList<SearchResponse>>
{
    private readonly DataContext _context;

    public SearchFlightsQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<IList<SearchResponse>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
    {
        const int tolerance = 30;
        var searchRequest = request.SearchRequest;
        var routes = await _context.Routes
            .Where(_ => _.DepartureDate >= searchRequest.StartDate)
            .Where(_ => _.DepartureDate <= searchRequest.EndDate)
            .Include(_ => _.Flights)
            .Join(_context.Subscriptions,
                route => new { route.OriginCityId, route.DestinationCityId },
                subscription => new { subscription.OriginCityId, subscription.DestinationCityId },
                (route, subscription) => new { route, subscription })
            .Where(_ => _.subscription.AgencyId == searchRequest.AgencyId)
            .Select(_ => _.route)
            .ToListAsync(cancellationToken);

        var flights = routes.Select(_ => new
            {
                NextWeek = routes.FirstOrDefault(r => r.DepartureDate == _.DepartureDate.AddDays(7)),
                LastWeek = routes.FirstOrDefault(r => r.DepartureDate == _.DepartureDate.AddDays(-7)),
                OriginCityId = _.OriginCityId,
                DestinationCityId = _.DestinationCityId,
                DepartureDate = _.DepartureDate,
                Flights = _.Flights
            }).SelectMany(_ => _.Flights.Select(flight => new SearchResponse()
            {
                FlightId = flight.Id,
                OriginCityId = _.OriginCityId,
                DestinationCityId = _.DestinationCityId,
                DepartureTime = flight.DepartureTime,
                ArrivalDate = flight.ArrivalDate,
                AirlineId = flight.AirlineId,
                New = !_.LastWeek?.Flights
                    .Select(f => (f.DepartureTime.TimeOfDay - flight.DepartureTime.TimeOfDay).TotalMinutes)
                    .Any(f => Math.Abs(f) <= tolerance),

                Discontinued = !_.NextWeek?.Flights
                    .Select(f => (f.DepartureTime.TimeOfDay - flight.DepartureTime.TimeOfDay).TotalMinutes)
                    .Any(f => Math.Abs(f) <= tolerance)
            }))
            .ToList();

        return flights;
    }
}