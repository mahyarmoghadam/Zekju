using MediatR;
using Zekju.Application.Flight.Dtos;

namespace Zekju.Application.Flight.QueryHandlers;

public sealed record SearchFlightsQuery(SearchRequest SearchRequest) : IRequest<IList<SearchResponse>> { }

public class SearchFlightsQueryHandler : IRequestHandler<SearchFlightsQuery, IList<SearchResponse>>
{
    public Task<IList<SearchResponse>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}