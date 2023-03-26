namespace Zekju.Application.Flight.Dtos;

public class SearchResponse
{
    public int FlightId { get; set; }
    public int OriginCityId { get; set; }
    public int DestinationCityId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalDate { get; set; }
    public int AirlineId { get; set; }
    public bool? Discontinued { get; set; }
    public bool? New { get; set; }
}