﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMeProgram.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Question> questions { get; set; }
        
        public override string ToString()
        {
            return $" Name : {this.Name}  id ({Id}) ";
        }
    }
}
