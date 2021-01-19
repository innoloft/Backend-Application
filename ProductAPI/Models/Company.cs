namespace ProductAPI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Company
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

        public string catchPhrase
        {
            get;
            set;
        }

        public string bs
        {
            get;
            set;
        }

        public ICollection<User> users
        {
            get;
            set;
        }
    }
}