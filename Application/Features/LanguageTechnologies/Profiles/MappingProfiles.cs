using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();

            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();

            CreateMap<LanguageTechnology, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();

            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(t => t.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();
        }
    }
}
