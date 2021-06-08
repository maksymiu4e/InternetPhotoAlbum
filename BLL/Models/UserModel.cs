﻿using System.Collections.Generic;

namespace BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public ICollection<PhotoModel> Photos { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public ICollection<string> Errors { get; set; }
        public UserModel()
        {
            Errors = new List<string>();
        }
    }

}
