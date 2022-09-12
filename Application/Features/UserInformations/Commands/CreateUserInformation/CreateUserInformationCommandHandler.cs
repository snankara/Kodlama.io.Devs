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

namespace Application.Features.UserInformations.Commands.CreateUserInformation
{
    public class CreateUserInformationCommandHandler : IRequestHandler<CreateUserInformationCommand, CreatedUserInformationDto>
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IMapper _mapper;

        public CreateUserInformationCommandHandler(IUserInformationRepository userInformationRepository, IMapper mapper)
        {
            _userInformationRepository = userInformationRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserInformationDto> Handle(CreateUserInformationCommand request, CancellationToken cancellationToken)
        {
            UserInformation userInformation = _mapper.Map<UserInformation>(request);

            UserInformation createdUserInformation = await _userInformationRepository.AddAsync(userInformation);

            CreatedUserInformationDto mappedUserInformation = _mapper.Map<CreatedUserInformationDto>(createdUserInformation);

            return mappedUserInformation;
        }
    }
}
