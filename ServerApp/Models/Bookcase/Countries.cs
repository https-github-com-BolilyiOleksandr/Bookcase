using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Countries
    {
        public Countries()
        {
            Authors = new HashSet<Authors>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Authors> Authors { get; set; }
    }
}
