using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
