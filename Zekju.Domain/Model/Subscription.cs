namespace Zekju.Domain.Model;

public class Subscription
{
    public Subscription(int agencyId, int originCityId, int destinationCityId)
    {
        AgencyId = agencyId;
        OriginCityId = originCityId;
        DestinationCityId = destinationCityId;
    }

    public int AgencyId { get; private set; }
    public int OriginCityId { get; private set; }
    public int DestinationCityId { get; private set; }
}