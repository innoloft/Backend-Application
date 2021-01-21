using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.ViewModels
{
    public class CommonVM
    {
        public Int32 IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Int64 DeletedBy { get; set; }
        public Int32 IsDeleted { get; set; }
    }
}
