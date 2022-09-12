using Application.Features.UserInformations.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserInformations.Commands.DeleteUserInformation
{
    public class DeleteUserInformationCommandHandler : IRequestHandler<DeleteUserInformationCommand, DeletedUserInformationDto>
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IMapper _mapper;

        public DeleteUserInformationCommandHandler(IUserInformationRepository userInformationRepository, IMapper mapper)
        {
            _userInformationRepository = userInformationRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserInformationDto> Handle(DeleteUserInformationCommand request, CancellationToken cancellationToken)
        {
            UserInformation userInformation = _mapper.Map<UserInformation>(request);

            UserInformation deletedUserInformation = await _userInformationRepository.DeleteAsync(userInformation);

            DeletedUserInformationDto mappedUserInformationDto = _mapper.Map<DeletedUserInformationDto>(deletedUserInformation);

            return mappedUserInformationDto;
        }
    }
}
