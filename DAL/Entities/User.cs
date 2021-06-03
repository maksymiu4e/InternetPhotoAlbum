using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : IdentityUser<int>
    {
        //public User()
        //{
        //    Photos = new List<Photo>();
        //    Likes = new List<Like>();
        //}
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public virtual ICollection<Like> Likes { get; set; }
    }
}
