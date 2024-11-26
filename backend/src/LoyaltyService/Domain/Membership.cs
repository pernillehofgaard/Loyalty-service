namespace LoyaltyService.Domain;

public class Membership
{
    public DateTime StartDate { get; set; }
    public int DurationInYears { get; set; }
    public int MaxRewardYears { get; set; }
    public List<ActiveReward> ActiveRewards { get; set; }
}