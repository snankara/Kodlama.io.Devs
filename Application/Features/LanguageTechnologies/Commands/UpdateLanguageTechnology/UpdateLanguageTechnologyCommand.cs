using Application.Features.LanguageTechnologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand : IRequest<UpdatedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
