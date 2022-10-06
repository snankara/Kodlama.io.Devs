using Application.Features.UserOperaitonClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperaitonClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperaitonClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperaitonClaims.Dtos;
using Application.Features.UserOperaitonClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperaitonClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimListDto>().ForMember(c => c.OperationClaimName,
                opt => opt.MapFrom(e => e.OperationClaim.Name)).ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
        }
    }
}
