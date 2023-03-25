namespace Zekju.Application.Flight.Dtos;

public class SearchRequest
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int AgencyId { get; private set; }

    private SearchRequest(){}
    public static SearchRequest Create(string[] args)
    {
        if (args.Length != 3)
        {
            throw new ArgumentException("Expected 3 arguments: startDate, endDate, agencyId");
        }

        if (!DateTime.TryParse(args[0], out var startDate))
        {
            throw new ArgumentException("Invalid startDate format");
        }

        if (!DateTime.TryParse(args[1], out var endDate))
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