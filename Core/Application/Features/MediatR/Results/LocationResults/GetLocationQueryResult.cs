﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Results.LocationResults
{
    public class GetLocationQueryResult
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}
