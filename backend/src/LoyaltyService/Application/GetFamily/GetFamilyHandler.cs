using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoyaltyService.Domain;
using MediatR;

namespace LoyaltyService.Application.GetFamily;

public class GetFamilyHandler :IRequestHandler<GetFamily, Family>
{
    public async Task<Family> Handle(GetFamily request, CancellationToken cancellationToken)
    {
        var breakdownList = new List<IceCashBreakdown>
        {
            new IceCashBreakdown
            {
                PointsEarned = 50,
                Year = 2025
            },
            new IceCashBreakdown
            {
                PointsEarned = 100,
                Year = 2024
            },
            new IceCashBreakdown
            {
                PointsEarned = 100,
                Year = 2024
            }
        };
        
        return new Family
        {
            Id = request.Id,
            Name = "FamilyGuys",
            Rewards = new Rewards
            {
                IceCash = new IceCash
                {
                    Total = GetIceCashHandler.GetTotalPoint(breakdownList),
                    Breakdown = breakdownList
                },
                IcePointsRewards = new List<IcePointsReward>
                {
                    new IcePointsReward
                    {
                        Id = "PointsRewardId",
                        Name = "iClound",
                        
                        ExpiryDate = DateTime.UtcNow.AddDays(365)
                    }
                }
            },
            Members = new List<FamilyMember>
            {
                new FamilyMember
                {
                    Id = "123",
                    Name = "Lise Larsen",
                }
            }
        };
    }
}