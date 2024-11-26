namespace LoyaltyService.Domain;

public class Family
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Membership Membership { get; set; }
    public List<FamilyMember> Members { get; set; }
    public Rewards Rewards { get; set; }
}