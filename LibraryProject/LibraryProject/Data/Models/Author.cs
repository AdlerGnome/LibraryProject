using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Data.Models
{
    public class Author
    {
        [Key]
        public int AId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Birthyear { get; set; }
        public int Deathyear { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
