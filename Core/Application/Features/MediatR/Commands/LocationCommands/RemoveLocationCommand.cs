﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Commands.LocationCommands
{
    public class RemoveLocationCommand : IRequest
    {
        public int LocationId { get; set; }

        public RemoveLocationCommand(int locationId)
        {
            LocationId = locationId;
        }
    }
}
