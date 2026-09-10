using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Request
{
    public class BookRequest
    {
        public string? Title { get; set; }
        public int Pagecount { get; set; }
        public int Edition { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public int PublishYear { get; set; }
        public int AId { get; set; }
        public int PId { get; set; }
    }
}
