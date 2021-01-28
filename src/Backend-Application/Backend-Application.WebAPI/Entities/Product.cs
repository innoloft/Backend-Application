using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Entities
{
    public class Product 
    {
        public int ProductId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int OwnerId { get; private set; }
        
        public Type Type { get; private set; }
        public int TypeId { get; private set; }


        public Product(string title, string description, int ownerId, Type type)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title is null or empty", nameof(title));
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description is null or empty", nameof(description));
            }
            this.Title = title;
            this.Description = description;
            this.Type = type;
            this.OwnerId = ownerId;
        }


        public void Update(string title, string description, int ownerId, Type type)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title is null or empty", nameof(title));
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description is null or empty", nameof(description));
            }
            this.Title = title;
            this.Description = description;
            this.Type = type;
            this.OwnerId = ownerId;
        }
        public Product() { }
    }
}
