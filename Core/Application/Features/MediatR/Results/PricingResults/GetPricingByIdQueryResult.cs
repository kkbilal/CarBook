﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Results.PricingResults
{
    public class GetPricingByIdQueryResult
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
