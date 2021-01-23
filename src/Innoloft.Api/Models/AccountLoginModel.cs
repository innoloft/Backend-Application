using System.ComponentModel.DataAnnotations;

namespace Innoloft.Api.Models
{
    public class AccountLoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
