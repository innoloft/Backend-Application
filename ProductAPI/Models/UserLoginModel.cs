namespace ProductAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginModel
    {
        [Required]
        public string userName
        {
            get;
            set;
        }

        [Required]
        public string password
        {
            get;
            set;
        }
    }
}