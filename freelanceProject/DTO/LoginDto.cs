using System.ComponentModel.DataAnnotations;

namespace freelanceProject.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage="UserName is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

    }
}
