using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Entities
{
    public class Type
    {
        public int TypeId { get; private set; }

        public string Name { get; private set; }

        public string ImageUri { get; private set; }

        private List<Product> _products = new List<Product>();

        public IReadOnlyCollection<Product> Products => _products;

        public Type(string name, string imageUri)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name is null or empty", nameof(name));
            }
            this.Name = name;
            this.ImageUri = imageUri;
        }

        public Type() { }
    }
}
