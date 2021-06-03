using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetPhotoAlbum.ViewModels.User
{
    public class SignUpViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not valid email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        public ICollection<string> Errors { get; set; }
        public SignUpViewModel()
        {
            Errors = new List<string>();
        }
    }
}
