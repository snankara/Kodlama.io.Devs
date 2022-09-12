using Application.Features.UserInformations.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserInformations.Commands.DeleteUserInformation
{
    public class DeleteUserInformationCommand : IRequest<DeletedUserInformationDto>
    {
        public int Id { get; set; }
    }
}
