namespace Zekju.Domain.Model;

public class Flight 
{
    public Flight(int id, int routeId, DateTime departureTime, DateTime arrivalDate, int airlineId)
    {
        Id = id;
        RouteId = routeId;
        DepartureTime = departureTime;
        ArrivalDate = arrivalDate;
        AirlineId = airlineId;
    }

    public int Id { get; private set; }
    public int RouteId { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public DateTime ArrivalDate { get; private set; }
    public int AirlineId { get; private set; }
    public Route Route { get; private set; } = null!;
}