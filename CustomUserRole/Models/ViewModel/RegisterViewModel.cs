using CustomUserRole.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomUserRole.Models.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}