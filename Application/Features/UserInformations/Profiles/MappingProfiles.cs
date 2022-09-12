using Application.Features.UserInformations.Commands.CreateUserInformation;
using Application.Features.UserInformations.Commands.DeleteUserInformation;
using Application.Features.UserInformations.Commands.UpdateUserInformation;
using Application.Features.UserInformations.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserInformations.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserInformation, CreateUserInformationCommand>().ReverseMap();
            CreateMap<UserInformation, CreatedUserInformationDto>().ReverseMap();

            CreateMap<UserInformation, UpdateUserInformationCommand>().ReverseMap();
            CreateMap<UserInformation, UpdatedUserInformationDto>().ReverseMap();

            CreateMap<UserInformation, DeleteUserInformationCommand>().ReverseMap();
            CreateMap<UserInformation, DeletedUserInformationDto>().ReverseMap();
        }
    }
}
