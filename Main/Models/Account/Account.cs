using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public Role[] Roles { get; set; }
    }
    public enum Role
    {
        Student, Teacher, Adminq
    }
}
