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
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterByIdQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var footer =await _repository.GetByIdAsync(request.Id);
            if (footer == null)
            {
                   throw new Exception("Footer not found");
            }
            return new GetFooterByIdQueryResult
            {
                
                Phone = footer.Phone,
                FooterId = footer.FooterId,
                Adress = footer.Adress,
                Mail = footer.Mail,
                Description = footer.Description
                
            };
        }
    }
}
