using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UserRegister
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserRegisteredDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public UserRegisterCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<UserRegisteredDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserShouldNotExist(request.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            User userToBeAdded = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true,
                AuthenticatorType = AuthenticatorType.None
            };

            User addedUser = await _userRepository.AddAsync(userToBeAdded);

            var userOperationClaims =  _userRepository.GetClaims(addedUser);
            var accessToken = _tokenHelper.CreateToken(addedUser, userOperationClaims);

            UserRegisteredDto mappedUserRegisteredDto = _mapper.Map<UserRegisteredDto>(accessToken);

            return mappedUserRegisteredDto;

        }
    }
}
