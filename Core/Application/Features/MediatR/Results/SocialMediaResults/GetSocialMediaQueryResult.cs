using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Results.SocialMediaResults
{
    public class GetSocialMediaQueryResult
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; }
    }
}
