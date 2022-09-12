using Application.Features.UserInformations.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserInformations.Commands.CreateUserInformation
{
    public class CreateUserInformationCommand : IRequest<CreatedUserInformationDto>
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
    }
}
