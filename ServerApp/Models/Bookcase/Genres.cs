using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Genres
    {
        public Genres()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string Genre { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
