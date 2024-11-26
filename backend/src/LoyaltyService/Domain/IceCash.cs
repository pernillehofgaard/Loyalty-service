using System.Collections.Generic;

namespace LoyaltyService.Domain;

public class IceCash
{
    public int Total { get; set; }
    public List<IceCashBreakdown> Breakdown { get; set; }
}