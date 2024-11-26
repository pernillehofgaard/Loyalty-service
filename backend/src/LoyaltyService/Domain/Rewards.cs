namespace LoyaltyService.Domain;

public class Rewards
{
    public IceCash IceCash { get; set; }
    public List<IcePointsReward> IcePointsRewards { get; set; }
}