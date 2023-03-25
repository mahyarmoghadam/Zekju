namespace Zekju.Domain.Model;

public class Subscription
{
    public Subscription(int id, int agencyId, int originCityId, int destinationCityId)
    {
        Id = id;
        AgencyId = agencyId;
        OriginCityId = originCityId;
        DestinationCityId = destinationCityId;
    }

    public int Id { get; private set; }
    public int AgencyId { get; private set; }
    public int OriginCityId { get; private set; }
    public int DestinationCityId { get; private set; }
}