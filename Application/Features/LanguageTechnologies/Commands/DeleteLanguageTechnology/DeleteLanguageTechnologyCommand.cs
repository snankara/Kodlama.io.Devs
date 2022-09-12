using Application.Features.LanguageTechnologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
    {
        public int Id { get; set; }
    }
}
