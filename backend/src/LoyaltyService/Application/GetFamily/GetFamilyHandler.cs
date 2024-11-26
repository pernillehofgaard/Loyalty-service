using LoyaltyService.Domain;
using MediatR;

namespace LoyaltyService.Application.GetFamily;

public class GetFamilyHandler :IRequestHandler<GetFamily, Family>
{
    public async Task<Family> Handle(GetFamily request, CancellationToken cancellationToken)
    {
        return new Family
        {
            Id = request.Id,
            Name = "FamilyGuys",
            Rewards = new Rewards(),
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