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

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly IMapper _mapper;

        public DeleteLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            LanguageTechnology? languageTechnologyToBeDeleted = await _languageTechnologyRepository.GetAsync(l => l.Id == request.Id);

            LanguageTechnology deletedLanguageTechnology = await _languageTechnologyRepository.DeleteAsync(languageTechnologyToBeDeleted);

            DeletedLanguageTechnologyDto mappedDeletedLanguageTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(deletedLanguageTechnology);

            return mappedDeletedLanguageTechnologyDto;
        }
    }
}
