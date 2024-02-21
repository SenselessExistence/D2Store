using System.ComponentModel.DataAnnotations;

namespace D2Store.Common.DTO.Authentication
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }


    }
}
