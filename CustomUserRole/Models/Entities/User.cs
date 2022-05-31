using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomUserRole.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}