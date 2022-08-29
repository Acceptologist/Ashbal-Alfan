using System.ComponentModel.DataAnnotations;

namespace freelanceProject.DTO
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "OldPassword is Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "NewPassword is Required")]
        public string NewPassword { get; set; }
    }
}
