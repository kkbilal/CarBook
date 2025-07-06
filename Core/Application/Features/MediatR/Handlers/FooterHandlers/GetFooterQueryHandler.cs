using Application.Features.MediatR.Queries.FooterQueries;
using Application.Features.MediatR.Results.FooterAddressResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.FooterHandlers
{
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var footers = await _repository.GetAllAsync();
            if( footers == null || !footers.Any() )
            {
                throw new Exception("No footers found");
            }
            return footers.Select(footer => new GetFooterQueryResult
            {
                Phone = footer.Phone,
                FooterId = footer.FooterId,
                Adress = footer.Adress,
                Mail = footer.Mail,
                Description = footer.Description
            }).ToList();
        }
    }
}
