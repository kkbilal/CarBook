﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateAboutCommand
    {
        public int AboutId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
