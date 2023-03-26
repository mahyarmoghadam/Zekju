namespace Zekju.Application.Flight.Dtos;

public class SearchRequest
{
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public int AgencyId { get; private set; }

    private SearchRequest(){}
    public static SearchRequest Create(string[] args)
    {
        if (args.Length != 3)
        {
            throw new ArgumentException("Expected 3 arguments: startDate, endDate, agencyId");
        }

        if (!DateOnly.TryParse(args[0], out var startDate))
        {
            throw new ArgumentException("Invalid startDate format");
        }

        if (!DateOnly.TryParse(args[1], out var endDate))
        {
            throw new ArgumentException("Invalid endDate format");
        }

        if (!int.TryParse(args[2], out var agencyId))
        {
            throw new ArgumentException("Invalid agencyId format");
        }

        var request = new SearchRequest
        {
            StartDate = startDate,
            EndDate = endDate,
            AgencyId = agencyId
        };
        
        return request;
    }
}