using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public virtual List<UserSocial> UserSocials { get; set; }
    }
}