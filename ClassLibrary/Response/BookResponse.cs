using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Response
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Pagecount { get; set; }
        public int Edition { get; set; }
        public int Stock { get; set; }
        public int PublishYear { get; set; }
        public string? Description { get; set; }
        public BookAuthorResponse? Author { get; set; }
        public int PId { get; set; }
    }

    public class BookAuthorResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Birthyear { get; set; }
        public int Deathyear { get; set; }
    }

    //publisher
    //genres
}
