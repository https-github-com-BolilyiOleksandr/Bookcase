using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Authors
    {
        public Authors()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public bool? Active { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
