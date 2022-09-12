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

namespace Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, UpdatedLanguageTechnologyDto>
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly IMapper _mapper;

        public UpdateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            LanguageTechnology languageTechnologyToBeUpdated = _mapper.Map<LanguageTechnology>(request);
            LanguageTechnology updatedLanguageTechnology = await _languageTechnologyRepository.UpdateAsync(languageTechnologyToBeUpdated);

            UpdatedLanguageTechnologyDto mappedLanguageTechnologyDto = _mapper.Map<UpdatedLanguageTechnologyDto>(updatedLanguageTechnology);

            return mappedLanguageTechnologyDto;
        }
    }
}
