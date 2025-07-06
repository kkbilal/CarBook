﻿using Application.Features.MediatR.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {

    }
}
