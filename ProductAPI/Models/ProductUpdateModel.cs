namespace ProductAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductUpdateModel
    {
        [Required]
        public int id
        {
            get;
            set;
        }

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
    }
}