﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BEZAO_PayDAL.Model
{
   public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime Birthday { get; set; }
    }
}
