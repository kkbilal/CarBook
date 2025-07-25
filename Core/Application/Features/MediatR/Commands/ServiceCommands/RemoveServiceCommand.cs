﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Commands.ServiceCommands
{
    public class RemoveServiceCommand : IRequest
    {
        public int ServiceId { get; set; }

        public RemoveServiceCommand(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
