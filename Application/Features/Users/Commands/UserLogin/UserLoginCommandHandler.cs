using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoggedInDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public UserLoginCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<UserLoggedInDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            User? userToCheck = await _userRepository.GetAsync(u => u.Email == request.Email);

            _userBusinessRules.UserMustExist(userToCheck);

            if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return null;

            var userOperationClaims = _userRepository.GetClaims(userToCheck);
            var accessToken = _tokenHelper.CreateToken(userToCheck, userOperationClaims);

            UserLoggedInDto mappedUserLoggedInDto = _mapper.Map<UserLoggedInDto>(accessToken);

            return mappedUserLoggedInDto;

        }
    }
}
