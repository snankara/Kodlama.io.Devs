using Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UserLogin
{
    public class UserLoginCommand : IRequest<UserLoggedInDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
