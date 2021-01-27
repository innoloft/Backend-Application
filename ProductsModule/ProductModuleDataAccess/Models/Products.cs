using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductModuleDataAccess.Models
{
    public class Products
    {
        [Key]
        public int productsid { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 10)]
        public int userid { get; set; }
        [NotMapped]
        public User user { get; set; } = null;
               
        public int contactid { get; set; }
        public Contacts Contact { get; set; }

        public int typeid { get; set; }
        public Types Type { get; set; }

        public override string ToString()
        {
            return $"productsid : {productsid}\n" +
                $"name: {name}\n description : {description}\n " +
                $"userid : {userid}\n contactid : {contactid}\n" +
                $"Contact : {Contact.ToString()}\n typeid : {typeid}\n Type : {Type.ToString()}";
        }
    }
}
