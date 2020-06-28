using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Ratings
    {
        public Ratings()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
