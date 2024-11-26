using System;

namespace LoyaltyService.Domain
{
    public class IcePointsReward
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
