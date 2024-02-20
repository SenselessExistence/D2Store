using System.ComponentModel.DataAnnotations;

namespace D2Store.Common.DTO.Authentication
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
