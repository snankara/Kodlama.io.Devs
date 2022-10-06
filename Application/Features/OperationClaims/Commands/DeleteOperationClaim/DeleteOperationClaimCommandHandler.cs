using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaimToBeDeleted = _mapper.Map<OperationClaim>(request);
            OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaimToBeDeleted);

            DeletedOperationClaimDto mappedOperationClaim = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);

            return mappedOperationClaim;
        }
    }
}
