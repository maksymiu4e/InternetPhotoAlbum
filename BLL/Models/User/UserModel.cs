﻿using BLL.Models.Photo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.User
{
    public class UserModel
    {
        //public int Id { get; set; }
        //public int RoleId { get; set; }
        ////public string Login { get; set; }
        //public string Email { get; set; }
        public ICollection<PhotoModel> Photos { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }

}