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

namespace Application.Features.UserInformations.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommandHandler : IRequestHandler<UpdateUserInformationCommand, UpdatedUserInformationDto>
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IMapper _mapper;

        public UpdateUserInformationCommandHandler(IUserInformationRepository userInformationRepository, IMapper mapper)
        {
            _userInformationRepository = userInformationRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserInformationDto> Handle(UpdateUserInformationCommand request, CancellationToken cancellationToken)
        {
            UserInformation userInformation = _mapper.Map<UserInformation>(request);

            UserInformation updatedUserInformation = await _userInformationRepository.UpdateAsync(userInformation);

            UpdatedUserInformationDto mappedUserInformationDto = _mapper.Map<UpdatedUserInformationDto>(updatedUserInformation);

            return mappedUserInformationDto;
        }
    }
}
