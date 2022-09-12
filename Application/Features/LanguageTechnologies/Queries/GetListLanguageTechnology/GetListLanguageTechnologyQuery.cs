using Application.Features.LanguageTechnologies.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology
{
    public class GetListLanguageTechnologyQuery : IRequest<LanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
