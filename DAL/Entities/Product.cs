using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? ContactPersonId { get; set; }
        public int? TypeId { get; set; }
        public int? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
    }
}
