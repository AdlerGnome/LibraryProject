using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Data.Models
{
    public class Book
    {
        [Key]
        public int BId { get; set; }
        public string? Title { get; set; }
        public int Pagecount { get; set; }
        public int Edition { get; set; }
        public int Stock { get; set; }
        public int PublishYear { get; set; }

        [Column(TypeName = "nvarchar(1500)")]
        public string? Description { get; set; }
        
        [ForeignKey("Author")]
        public int AId { get; set; }
        public virtual Author? Author { get; set; }
        
        [ForeignKey("Publisher")]
        public int PId { get; set; }
        public virtual Publisher? Publisher { get; set; }

        public virtual ICollection<Genre>? Genres { get; set; }

    }
}
