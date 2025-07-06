using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Results
{
    public class GetFeatureQueryResult
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
    }
}
