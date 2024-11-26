namespace LoyaltyService.Domain;

public class FamilyMember
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Role { get; set; }
    public string Product { get; set; }
    public string Msisdn { get; set; }
    public int PointsEarned { get; set; }
    public DateTime MemberSince { get; set; }
}