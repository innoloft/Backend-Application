using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductModuleDataAccess.Models
{
    public class Types
    {
        [Key]
        public int typesid { get; set; }

        [Required]
        public string name { get; set; }

        public override string ToString()
        {
            return $"typesid : {typesid}\n name: {name}";
        }
    }
}
