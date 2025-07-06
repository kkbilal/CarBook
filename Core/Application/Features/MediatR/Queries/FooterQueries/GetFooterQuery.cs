using Application.Features.MediatR.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Queries.FooterQueries
{
    public class GetFooterQuery : IRequest<List<GetFooterQueryResult>>
    {
    }
}
