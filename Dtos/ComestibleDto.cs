using System.Text.Json.Serialization;
using crud.Models;

namespace crud.Dtos
{
    public class ComestibleDto
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}