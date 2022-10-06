using Application.Features.UserOperaitonClaims.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.UserOperaitonClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
