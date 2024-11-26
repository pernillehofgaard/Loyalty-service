using LoyaltyService.Domain;
using MediatR;

namespace LoyaltyService.Application.GetFamily;

public class GetFamily : IRequest<Family>
{
    public string? Id { get; set; }
}