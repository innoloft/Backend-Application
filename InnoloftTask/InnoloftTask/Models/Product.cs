using System;
namespace InnoloftTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
