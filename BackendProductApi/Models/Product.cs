using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int OwnerId { get; set; }

        
    }
}
