﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain
{
    public class User
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public long Id { get; set; }
    }
}
