using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Contactperson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
    }
}
