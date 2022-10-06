using Application.Features.UserOperaitonClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperaitonClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaimToBeUpdated = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(userOperationClaimToBeUpdated);

            UpdatedUserOperationClaimDto mappedUserOperationClaim = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);

            return mappedUserOperationClaim;
        }
    }
}
