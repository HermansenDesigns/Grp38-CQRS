﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    class ProductQuick
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Rating { get; set; }
    }
}