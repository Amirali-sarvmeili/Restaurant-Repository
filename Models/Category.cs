

namespace crud.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
        
        public ICollection<Comestible> Comestibles { get; set; } = new List<Comestible>();
    }
}