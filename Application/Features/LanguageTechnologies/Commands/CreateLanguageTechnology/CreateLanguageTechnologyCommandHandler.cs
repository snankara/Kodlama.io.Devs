using Application.Features.LanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly IMapper _mapper;

        public CreateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            LanguageTechnology languageTechnology = _mapper.Map<LanguageTechnology>(request);
            LanguageTechnology createdLanguageTechnology = await _languageTechnologyRepository.AddAsync(languageTechnology);

            CreatedLanguageTechnologyDto mappedLanguageTechnologyDto = _mapper.Map<CreatedLanguageTechnologyDto>(createdLanguageTechnology);

            return mappedLanguageTechnologyDto;
        }
    }
}
