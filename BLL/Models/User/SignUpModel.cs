using System.Collections.Generic;

namespace BLL.Models.User
{
    public class SignUpModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public ICollection<string> Errors { get; set; }
        public SignUpModel()
        {
            Errors = new List<string>();
        }
    }
}
