using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoyaltyService.Domain;
using LoyaltyService.Infrastructure;
using MediatR;

namespace LoyaltyService.Application.GetFamily;

public class GetFamilyHandler(IFamilyRepository famrep) :IRequestHandler<GetFamily, Family>
{
    
    public async Task<Family> Handle(GetFamily request, CancellationToken cancellationToken)
    {
        return await famrep.GetFamily(request.Id);
    }
}