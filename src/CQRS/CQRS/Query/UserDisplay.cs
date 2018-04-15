﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Command;

namespace CQRS.Query
{
    public class UserDisplay
    {
        public RenameUserCommand LatestRenameUserCommand { get; set; }
        public UserDisplay(long id, string name, DateTime age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        [Key]
        public long LocalId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        
    }
}
