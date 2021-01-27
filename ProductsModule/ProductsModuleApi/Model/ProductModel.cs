using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsModuleApi.Model
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [Range(minimum: 1, maximum: 10, ErrorMessage = "Id allowed 1 to 10")]
        public int userid { get; set; }

        [Required(ErrorMessage = "ContactId is required")]
        public int contactid { get; set; }

        [Required(ErrorMessage = "TypeId is required")]
        public int typeid { get; set; }        
    }    
}
