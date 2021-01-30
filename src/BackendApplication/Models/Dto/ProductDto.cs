using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BackendApplication.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProductTypeEnum Type { get; set; }
        public ShortUserDto User { get; set; }
    }
}