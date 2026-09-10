using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Data.Models
{
    public class Publisher
    {
        [Key]
        public int PId { get; set; }
        public string? Name { get; set; }

    }
}
