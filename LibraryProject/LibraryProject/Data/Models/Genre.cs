using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Data.Models
{
    public class Genre
    {
        [Key] 
        public int GId { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
