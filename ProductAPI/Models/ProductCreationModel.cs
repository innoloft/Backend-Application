namespace ProductAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreationModel
    {
        [Required]
        public string name
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        [Required]
        public ProductType type
        {
            get;
            set;
        }

        public int userId
        {
            get;
            set;
        }
    }
}