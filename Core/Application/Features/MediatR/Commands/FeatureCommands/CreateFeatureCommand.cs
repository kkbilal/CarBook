﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Commands.FeatureCommands
{
    public class CreateFeatureCommand : IRequest
    {
        
        public string Name { get; set; }
    }
}
