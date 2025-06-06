
using System.Text.Json.Serialization;

namespace crud.Models
{
    public class Comestible
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}