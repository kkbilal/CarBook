﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public int Id { get; set; }

        public RemoveContactCommand(int contactId)
        {
            Id = contactId;
        }

        // Additional properties or methods can be added here if needed
    }
}
