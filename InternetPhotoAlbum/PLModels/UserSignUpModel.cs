using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetPhotoAlbum.PLModels
{
    public class UserSignUpModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
    public class UserSignInModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
