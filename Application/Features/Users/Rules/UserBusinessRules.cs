using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserMustExist(User user)
        {
            if (user == null) throw new BusinessException("User does not exist.");

        }

        public async Task UserShouldNotExist(string email)
        {
            User? userToCheck = await _userRepository.GetAsync(u => u.Email == email);
            if (userToCheck != null) throw new BusinessException("User already exists.");

        }
    }
}
