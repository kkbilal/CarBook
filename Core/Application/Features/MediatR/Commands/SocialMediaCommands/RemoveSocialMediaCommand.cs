﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand : IRequest
    {
        public int SocialMediaId { get; set; }

        public RemoveSocialMediaCommand(int socialMediaId)
        {
            SocialMediaId = socialMediaId;
        }
    }
}
