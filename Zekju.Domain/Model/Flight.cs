namespace Zekju.Domain.Model;

public class Flight 
{
    public Flight(int id, int routeId, int airlineId, DateTime departureTime, DateTime arrivalDate)
    {
        Id = id;
        RouteId = routeId;
        AirlineId = airlineId;
        DepartureTime = departureTime;
        ArrivalDate = arrivalDate;
    }

    public int Id { get; private set; }
    public int RouteId { get; private set; }
    public int AirlineId { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public DateTime ArrivalDate { get; private set; }
    public Route Route { get; private set; } = null!;
}