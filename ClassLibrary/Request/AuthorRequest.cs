using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Request
{
    public class AuthorRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Birthyear { get; set; }
        public int Deathyear { get; set; }
    }
}
