using LoyaltyService.Domain;
using LoyaltyService.Infrastructure;
using MediatR;

namespace LoyaltyService.Application.GetFamily;

public class GetFamilyHandler(IFamilyRepository familyRepository) :IRequestHandler<GetFamily, Family>
{
    public async Task<Family> Handle(GetFamily request, CancellationToken cancellationToken)
    {
        var familiy = await familyRepository.GetFamily(request.Id);
        return familiy;
    }
}