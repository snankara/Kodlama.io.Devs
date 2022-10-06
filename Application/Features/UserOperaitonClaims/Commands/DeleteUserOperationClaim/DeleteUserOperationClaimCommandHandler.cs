﻿using Application.Features.UserOperaitonClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperaitonClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaimToBeDeleted = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaimToBeDeleted);
        
            DeletedUserOperationClaimDto mappedUserOperationClaim = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);

            return mappedUserOperationClaim;
        }
    }

}
