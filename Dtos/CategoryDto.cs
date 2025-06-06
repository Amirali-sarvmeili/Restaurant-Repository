using System.Text.Json.Serialization;
using crud.Models;

namespace crud.Dtos
{
    public class CategoryDto
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
    }
}