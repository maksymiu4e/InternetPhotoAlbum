using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserProfileModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public UserModel User { get; set; }
    }
}
