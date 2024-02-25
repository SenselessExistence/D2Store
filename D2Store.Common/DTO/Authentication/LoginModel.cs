using System.ComponentModel.DataAnnotations;

namespace D2Store.Common.DTO.Authentication
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
