using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
        {
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

            _authBusinessRules.UserMustWhenLoggedIn(user);

            if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            LoggedInDto loggedInDto = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };

            return loggedInDto;
        }
    }
}
