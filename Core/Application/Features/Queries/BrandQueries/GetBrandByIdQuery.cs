﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.BrandQueries
{
    public class GetBrandByIdQuery
    {
        public int Id { get; set; }
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }
    }
}
