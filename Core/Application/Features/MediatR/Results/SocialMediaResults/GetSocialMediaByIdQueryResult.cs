using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Results.SocialMediaResults
{
    public class GetSocialMediaByIdQueryResult
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; }
    }
}
