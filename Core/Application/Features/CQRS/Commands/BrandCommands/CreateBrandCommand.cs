﻿using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {

        public string Name { get; set; }

    }
}
