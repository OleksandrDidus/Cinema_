﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } 

    }
}