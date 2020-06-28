using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Languages
    {
        public Languages()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string Language { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
