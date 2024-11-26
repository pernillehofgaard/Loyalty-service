using LoyaltyService.Domain;

namespace LoyaltyService.Infrastructure;

public interface IFamilyRepository
{
    public Task<Family> GetFamily(string id);
}