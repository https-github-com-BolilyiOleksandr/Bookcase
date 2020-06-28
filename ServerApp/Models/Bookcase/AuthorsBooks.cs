using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class AuthorsBooks
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public bool? Active { get; set; }

        public virtual Authors Author { get; set; }
        public virtual Books Book { get; set; }
    }
}
