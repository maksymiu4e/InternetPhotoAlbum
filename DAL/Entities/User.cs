using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
