using Application.Features.LanguageTechnologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommand : IRequest<CreatedLanguageTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
