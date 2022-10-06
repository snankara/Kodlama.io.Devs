using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaimToBeUpdated = _mapper.Map<OperationClaim>(request);
            OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaimToBeUpdated);

            UpdatedOperationClaimDto mappedOperationClaim = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

            return mappedOperationClaim;
        }
    }
}
