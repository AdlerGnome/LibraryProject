using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Data.Models
{
    public class BorrowedBook
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string? UId { get; set; }

        [ForeignKey("Book")]
        public int BId { get; set; }
    }
}
