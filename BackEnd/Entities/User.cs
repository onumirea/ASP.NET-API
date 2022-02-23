using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
