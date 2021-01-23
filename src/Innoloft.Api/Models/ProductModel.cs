using System;

namespace Innoloft.Api.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public int PersonId { get; set; }
        public bool IsActive { get; set; }
        public PersonModel ContactPerson { set; get; }
        public ProductTypeModel ProductType { set; get; }
    }
}
