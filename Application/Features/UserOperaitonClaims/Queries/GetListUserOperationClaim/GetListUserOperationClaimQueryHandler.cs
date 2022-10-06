using Application.Features.UserOperaitonClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperaitonClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(include:
                                                                                                                  t => t.Include(t => t.OperationClaim).
                                                                                                                  Include(t => t.User),
                                                                                                                  index: request.PageRequest.Page,
                                                                                                                  size: request.PageRequest.PageSize) ;
            
            UserOperationClaimListModel mappedUserOperationClaim = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);

            return mappedUserOperationClaim;
        }
    }
}
