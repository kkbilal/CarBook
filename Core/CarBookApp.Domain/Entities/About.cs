﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Domain.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
