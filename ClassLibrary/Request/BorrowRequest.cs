using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Request
{
    public class BorrowRequest
    {
        public string? UId { get; set; }
        public int BId { get; set; }
        public string? Username { get; set; }
    }
}
