using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public User User { get; set; }
    }
}
