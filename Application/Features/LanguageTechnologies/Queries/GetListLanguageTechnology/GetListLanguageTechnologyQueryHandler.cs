using Application.Features.LanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology
{
    public class GetListLanguageTechnologyQueryHandler : IRequestHandler<GetListLanguageTechnologyQuery, LanguageTechnologyListModel>
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<LanguageTechnologyListModel> Handle(GetListLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageTechnology> languageTechnologies = await _languageTechnologyRepository.GetListAsync(include: 
                                                                                                                  t => t.Include(t => t.ProgrammingLanguage),
                                                                                                                  index: request.PageRequest.Page, 
                                                                                                                  size: request.PageRequest.PageSize);

            LanguageTechnologyListModel mappedLanguageTechnologies = _mapper.Map<LanguageTechnologyListModel>(languageTechnologies);

            return mappedLanguageTechnologies;
        }
    }
}
