namespace ProductAPI.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get;
            set;
        }

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

        public ProductType type
        {
            get;
            set;
        }

        public User owner
        {
            get;
            set;
        }

        public int ownerId
        {
            get;
            set;
        }
    }
}