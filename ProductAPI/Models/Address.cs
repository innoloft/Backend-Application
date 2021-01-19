namespace ProductAPI.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get;
            set;
        }

        public string street
        {
            get;
            set;
        }

        public string suite
        {
            get;
            set;
        }

        public string city
        {
            get;
            set;
        }

        public string zipcode
        {
            get;
            set;
        }

        public string latitude
        {
            get;
            set;
        }

        public string longitude
        {
            get;
            set;
        }

        public int userId
        {
            get;
            set;
        }

        public User user
        {
            get;
            set;
        }
    }
}