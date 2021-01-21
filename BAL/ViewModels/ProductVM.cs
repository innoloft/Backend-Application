using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.ViewModels
{
    public class ProductVM : CommonVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? ContactPersonId { get; set; }
        public string ContactPersonName{ get; set; }
        public string ContactPersPhone { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
