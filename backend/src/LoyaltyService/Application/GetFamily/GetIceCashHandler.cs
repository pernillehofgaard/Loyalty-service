using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoyaltyService.Domain;
using MediatR;

namespace LoyaltyService.Application.GetFamily;

public class GetIceCashHandler : IRequestHandler<GetIceCash, IceCash>
{
    public async Task<IceCash> Handle(GetIceCash request, CancellationToken cancellationToken)
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
        
        return new IceCash
        {
            
            Total = GetTotalPoint(breakdownList),
            Breakdown = breakdownList
        };
    }

    public static int GetTotalPoint(List<IceCashBreakdown> breakdownList)
    {
        var sum = 0;
        foreach (var pointsEarned in breakdownList)
        {
            sum = pointsEarned.PointsEarned + sum;
        }

        return sum;
    }
}