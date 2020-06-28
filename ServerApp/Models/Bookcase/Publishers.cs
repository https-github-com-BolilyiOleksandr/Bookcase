using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Publishers
    {
        public Publishers()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string Publisher { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
