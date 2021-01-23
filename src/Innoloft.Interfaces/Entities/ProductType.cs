using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Interfaces.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Product> Products { set; get; }
    }
}
